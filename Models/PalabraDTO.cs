namespace ExamenProgramacion.Models
{
    public class PalabraDTO
    {
        public string Palabra { get; set; }
        public int A { get; set; }
        public int E { get; set; }
        public int I { get; set; }
        public int O { get; set; }
        public int U { get; set; }

    }
    
    public class Palabras
    {
        public List<string> a { get; set; }
        public List<string> e { get; set; }
        public List<string> i { get; set; }
        public List<string> o { get; set; }
        public List<string> u { get; set; }

    }
}
