namespace CourseApp.Models
{
    public static class Repository
    {
        //Liste tanımlandığı yerde oluşturulmaktadır
        private static List<Candidate> applications = new();

        //Class içerisindeki listeye bakılarak yanıt alınacak
        public static IEnumerable<Candidate> Applications => applications;

        public static void Add(Candidate candidate)
        {
            //Kullanıcıdan alınan başvuru direkt olarak liste içerisine eklenecektir
            applications.Add(candidate);
        }
    }
}
