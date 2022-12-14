using Bogus;
using ExamenProgramacion.Models;

namespace ExamenProgramacion.Service
{
    public class DataGeneratorService : IDataGeneratorService
    {
        public List<int> GenerarNumeros()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 25; i++)
            {
                list.Add(new Random().Next(0, 500));
            }
            return list;
        }

        public List<PalabraDTO> GenerarPalabras()
        {
            List<PalabraDTO> list = new List<PalabraDTO>();
            for (int i = 0; i < 100; i++)
            {
                var palabra = new Faker<PalabraDTO>()
                    .RuleFor(x => x.Palabra, f => f.Lorem.Word());
                list.Add(palabra.Generate());
            }
            return list;
        }

        public List<Persona> GenerarPersonas()
        {
            try
            {
                var personas = new List<Persona>();
                for (int i = 0; i < 500; i++)
                {
                    var persona = new Faker<Persona>()
                        .RuleFor(x => x.Edad, (f, x) => f.Random.Number(10, 100))
                        .RuleFor(x => x.Nombre, (f, x) => f.Name.FirstName());
                    personas.Add(persona.Generate());
                }

                return personas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
