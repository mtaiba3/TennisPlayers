using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TennisPlayers.Infrastructure
{
    public sealed class PlayerEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public string Sex { get; set; }
        public CountryEntity Country { get; set; }
        public string Picture { get; set; }
        public DataEntity Data { get; set; }
    }

    public sealed class CountryEntity
    {
        public string Picture { get; set; }
        public string Code { get; set; }
    }

    public sealed class DataEntity
    {
        public int Rank { get; set; }
        public int points { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public int[] Last { get; set; }
    }
}
