using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer()
        {
            this.Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
