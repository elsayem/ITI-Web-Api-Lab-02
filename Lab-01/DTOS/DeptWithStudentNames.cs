namespace Lab_01.DTOS
{
    public class DeptWithStudentNames
    {
        public int Department_Number { get; set; }
        public string Department_Name { get; set; }
        public string Department_Manger { get; set; }
        public string Department_Location { get; set; }
        public List<string> Student_Names { get; set; } = new List<string>();

    }
}
