using ExamenProgramacion.Models;

namespace ExamenProgramacion.Service
{
    public interface IDataGeneratorService
    {
        List<int> GenerarNumeros();
        List<PalabraDTO> GenerarPalabras();
        List<Persona> GenerarPersonas();
    }
}
