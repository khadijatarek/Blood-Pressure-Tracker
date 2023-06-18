using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bloodpressure_wcf
{
    
    [ServiceContract]
    public interface IBloodPressureWCF
    {
        [OperationContract]
        string GetDietRecommendation(string email, double systolicBP, double diastolicBP );

        [OperationContract]
        string GetBloodPressureRange(double systolicBP, double diastolicBP);



        [OperationContract]
        List<BloodPressureReading> GetBloodPressureReadings(int id);

        [OperationContract(IsOneWay = false)]
        String getReminder(int id);
    }
}
    [DataContract]
    public class BloodPressureReading
    {

        [DataMember]
        public DateTime ReadingDate { get; set; }

        [DataMember]
        public int Systolic { get; set; }

        [DataMember]
        public int Diastolic { get; set; }
    }

