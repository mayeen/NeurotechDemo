﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeurotechDemo;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Standards;
using System.IO;
using NeurotechDemo.Model;
using System.Windows.Forms;
using Neurotec.Licensing;
using Neurotec.Biometrics.Client;
using Neurotec.Devices;

namespace NeurotechDemo.Controller
{
    class ControllerUtils
    {
        public ControllerUtils()
        {

        }
        public NSubject FingerViewController(NSubject subject, NBiometricClient biometricClient)
        {
            using (biometricClient = new NBiometricClient { UseDeviceManager = true })
            using (var deviceManager = biometricClient.DeviceManager)
            {
                deviceManager.DeviceTypes = NDeviceType.FingerScanner;
                deviceManager.Initialize();
                biometricClient.FingerScanner = (NFScanner)deviceManager.Devices[0];
                if(biometricClient.FingerScanner == null)
                {
                    MessageBox.Show("Please connect your fingerprint scanner");
                }            
               else{
                    NFinger subjectFinger = new NFinger();
                    MessageBox.Show("Place your finger on the scanner");
                    subjectFinger.CaptureOptions = NBiometricCaptureOptions.Stream;
                    subject = new NSubject();
                    subject.Fingers.Add(subjectFinger);
                }
                
            }
            return subject;
        }
        //save template into directory
        public static void SaveTemplate(NSubject subject)
        {
            try
            {
                BdifStandard standard = BdifStandard.Unspecified;
                //ISO or ANSI template stadard can be set before extraction
                Console.WriteLine("{0} template extracted.", standard == BdifStandard.Iso ?
                "ISO" : standard == BdifStandard.Ansi ? "ANSI" : "Proprietary");
                Console.WriteLine("Template extracted");


                if (standard == BdifStandard.Iso)
                {   //create BDifStandard.ISO template
                    File.WriteAllBytes(Config.TemplateNameISO() , subject.GetTemplateBuffer(CbeffBiometricOrganizations.IsoIecJtc1SC37Biometrics,
                        CbeffBdbFormatIdentifiers.IsoIecJtc1SC37BiometricsFingerMinutiaeRecordFormat,
                        FMRecord.VersionIsoCurrent).ToArray());
                    Console.WriteLine("ISO template saved successfully");
                }
                else if (standard == BdifStandard.Ansi)
                {
                    //create BDifStandard.ANSI template
                    File.WriteAllBytes(Config.TemplateNameANSI(), subject.GetTemplateBuffer(CbeffBiometricOrganizations.IncitsTCM1Biometrics,
                        CbeffBdbFormatIdentifiers.IncitsTCM1BiometricsFingerMinutiaeU,
                        FMRecord.VersionAnsiCurrent).ToArray());
                    Console.WriteLine("ANSI template saved successfully");
                }
                else
                {
                    //create general template  
                    File.WriteAllBytes(Config.TemplateNameGeneral(), subject.GetTemplateBuffer().ToArray());
                    Console.WriteLine("template saved successfully");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void ObtainLicense(string components)
        {
            try
            {    //Licenses obtain for components
                if (!NLicense.ObtainComponents("/local", 5000, components))
                {

                    throw new ApplicationException(string.Format("Could not obtain licenses for components: { 0 }", components));

                }

            }
            catch
            {
                Console.WriteLine(components);

            }
        }

    }
}
