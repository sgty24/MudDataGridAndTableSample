using System.ComponentModel.DataAnnotations;

namespace MudDataGridAndTableSample.Data
{
  public class Element : IEquatable<Element>, IComparable<Element>
  {
    [Required(ErrorMessage = "{0} is required")]
    public int? Number { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public string? Sign { get; set; } = "";

    [Required(ErrorMessage = "{0} is required")]
    public string? Name { get; set; } = "";

    [Required(ErrorMessage = "{0} is required")]
    public Double? Molar { get; set; } = 0.0;

    [Required(ErrorMessage = "Melting point is required")]
    [CheckMeltByBoil(ErrorMessage = "Boiling point must be higher than melting point.")]
    public Double? MeltingPoint { get; set; } = 0.0;

    [Required(ErrorMessage = "Boiling point is required")]
    [CheckBoilByMelt(ErrorMessage = "Boiling point must be higher than melting point.")]
    public Double? BoilingPoint { get; set; } = 0.0;

    public bool Equals(Element? _obj) => _obj is null ? false : (this.Number == _obj.Number);

    public override bool Equals(object? _obj) => _obj is Element element && Equals(element);

    public override int GetHashCode() => this.Number is null ? 0 : (int)this.Number;

    public int CompareTo(Element? _obj)
    {
      if (_obj is null)
      {
        return -1;
      }
      else if (this.Equals(_obj))
      {
        return 0;
      }
      else if (this.Number < _obj.Number)
      {
        return -1;
      }
      else
      {
        return 1;
      }
    }

    public Element Clone() => (Element)MemberwiseClone();

    public void CopyTo(Element _dest)
    {
        _dest.Number = this.Number;
        _dest.Sign = this.Sign;
        _dest.Name = this.Name;
        _dest.Molar = this.Molar;
        _dest.MeltingPoint = this.MeltingPoint;
        _dest.BoilingPoint = this.BoilingPoint;
    }

    public static List<Element> GetTestData()
    {
      var ret = new List<Element>() {
        new Element { Number = 1, Sign = "H", Name = "Hydrogen", Molar = 1.01, MeltingPoint = -259.14, BoilingPoint = -252.87 },
        new Element { Number = 2, Sign = "He", Name = "Helium", Molar = 4.00, MeltingPoint = -272.2, BoilingPoint = -268.93 },
        new Element { Number = 3, Sign = "Li", Name = "Lithium", Molar = 6.94, MeltingPoint = 180.54, BoilingPoint = 1347.0 },
        new Element { Number = 4, Sign = "Be", Name = "Beryllium", Molar = 9.01, MeltingPoint = 1278.0, BoilingPoint = 2970.0 },
        new Element { Number = 5, Sign = "B", Name = "Boron", Molar = 10.81, MeltingPoint = 2300.0, BoilingPoint = 4200.0 },
        new Element { Number = 6, Sign = "C", Name = "Carbon", Molar = 12.01, MeltingPoint = 3915.0, BoilingPoint = 4300.0 },
        new Element { Number = 7, Sign = "N", Name = "Nitrogen", Molar = 14.01, MeltingPoint = -209.86, BoilingPoint = -195.8 },
        new Element { Number = 8, Sign = "O", Name = "Oxygen", Molar = 16.00, MeltingPoint = -218.79, BoilingPoint = -183.0 },
        new Element { Number = 9, Sign = "F", Name = "Fluorine", Molar = 19.00, MeltingPoint = -219.62, BoilingPoint = -188.14 },
        new Element { Number = 10, Sign = "Ne", Name = "Neon", Molar = 20.18, MeltingPoint = -248.59, BoilingPoint = -246.08 },
        new Element { Number = 11, Sign = "Na", Name = "Sodium", Molar = 22.99, MeltingPoint = 97.72, BoilingPoint = 883.0 },
        new Element { Number = 12, Sign = "Mg", Name = "Magnesium", Molar = 24.31, MeltingPoint = 650.0, BoilingPoint = 1090.0},
        new Element { Number = 13, Sign = "Al", Name = "Aluminum", Molar = 26.98, MeltingPoint = 660.32, BoilingPoint = 2467.0},
        new Element { Number = 14, Sign = "Si", Name = "Silicon", Molar = 28.09, MeltingPoint = 1410.0, BoilingPoint = 2355.0},
        new Element { Number = 15, Sign = "P", Name = "Phosphorus", Molar = 30.973762, MeltingPoint = 44.1, BoilingPoint = 280.0 },
        new Element { Number = 16, Sign = "S", Name = "Sulfur", Molar = 32.065, MeltingPoint = 115.21, BoilingPoint = 444.67 },
        new Element { Number = 17, Sign = "Cl", Name = "Chlorine", Molar = 35.453, MeltingPoint = -101.5, BoilingPoint = -34.04 },
        new Element { Number = 18, Sign = "Ar", Name = "Argon", Molar = 39.948, MeltingPoint = -189.3, BoilingPoint = -185.9 },
        new Element { Number = 19, Sign = "K", Name = "Potassium", Molar = 39.0983, MeltingPoint = 63.65, BoilingPoint = 774.0 },
        new Element { Number = 20, Sign = "Ca", Name = "Calcium", Molar = 40.078, MeltingPoint = 839.0, BoilingPoint = 1484.0 },
        new Element { Number = 21, Sign = "Sc", Name = "Scandium", Molar = 44.955912, MeltingPoint = 1539.0, BoilingPoint = 2832.0 },
        new Element { Number = 22, Sign = "Ti", Name = "Titanium", Molar = 47.867, MeltingPoint = 1660.0, BoilingPoint = 3287.0 },
        new Element { Number = 23, Sign = "V", Name = "Vanadium", Molar = 50.9415, MeltingPoint = 1910.0, BoilingPoint = 3380.0 },
        new Element { Number = 24, Sign = "Cr", Name = "Chromium", Molar = 51.9961, MeltingPoint = 1857.0, BoilingPoint = 2671.0 },
        new Element { Number = 25, Sign = "Mn", Name = "Manganese", Molar = 54.938045, MeltingPoint = 1246.0, BoilingPoint = 2061.0 },
        new Element { Number = 26, Sign = "Fe", Name = "Iron", Molar = 55.845, MeltingPoint = 1538.0, BoilingPoint = 2862.0 },
        new Element { Number = 27, Sign = "Co", Name = "Cobalt", Molar = 58.933, MeltingPoint = 1495.0, BoilingPoint = 2927.0 },
        new Element { Number = 28, Sign = "Ni", Name = "Nickel", Molar = 58.69, MeltingPoint = 1453.0, BoilingPoint = 2732.0 },
        new Element { Number = 29, Sign = "Cu", Name = "Copper", Molar = 63.546, MeltingPoint = 1084.0, BoilingPoint = 2562.0 },
        new Element { Number = 30, Sign = "Zn", Name = "Zinc", Molar = 65.38, MeltingPoint = 419.58, BoilingPoint = 907.0 },
        new Element { Number = 31, Sign = "Ga", Name = "Gallium", Molar = 69.723, MeltingPoint = 29.76, BoilingPoint = 2204.0 },
        new Element { Number = 32, Sign = "Ge", Name = "Germanium", Molar = 72.61, MeltingPoint = 937.4, BoilingPoint = 2830.0 },
        new Element { Number = 33, Sign = "As", Name = "Arsenic", Molar = 74.922, MeltingPoint = 817.0, BoilingPoint = 613.0 },
        new Element { Number = 34, Sign = "Se", Name = "Selenium", Molar = 78.96, MeltingPoint = 221.0, BoilingPoint = 685.0 },
        new Element { Number = 35, Sign = "Br", Name = "Bromine", Molar = 79.904, MeltingPoint = -7.2, BoilingPoint = 59.0 },
        new Element { Number = 36, Sign = "Kr", Name = "Krypton", Molar = 83.8, MeltingPoint = -157.2, BoilingPoint = -153.22 },
        new Element { Number = 37, Sign = "Rb", Name = "Rubidium", Molar = 85.468, MeltingPoint = 39.31, BoilingPoint = 688.0 },
        new Element { Number = 38, Sign = "Sr", Name = "Strontium", Molar = 87.62, MeltingPoint = 769, BoilingPoint = 1384 },
        new Element { Number = 39, Sign = "Y", Name = "Yttrium", Molar = 88.91, MeltingPoint = 1526, BoilingPoint = 3337 },
        new Element { Number = 40, Sign = "Zr", Name = "Zirconium", Molar = 91.22, MeltingPoint = 1855, BoilingPoint = 4409 },
        new Element { Number = 41, Sign = "Nb", Name = "Niobium", Molar = 92.91, MeltingPoint = 2468, BoilingPoint = 4927 },
        new Element { Number = 42, Sign = "Mo", Name = "Molybdenum", Molar = 95.94, MeltingPoint = 2617, BoilingPoint = 4612 },
        new Element { Number = 43, Sign = "Tc", Name = "Technetium", Molar = 98, MeltingPoint = 2200, BoilingPoint = 4877 },
        new Element { Number = 44, Sign = "Ru", Name = "Ruthenium", Molar = 101.1, MeltingPoint = 2236, BoilingPoint = 3900 },
        new Element { Number = 45, Sign = "Rh", Name = "Rhodium", Molar = 102.9, MeltingPoint = 1966, BoilingPoint = 3727 },
        new Element { Number = 46, Sign = "Pd", Name = "Palladium", Molar = 106.4, MeltingPoint = 1552, BoilingPoint = 2927 },
        new Element { Number = 47, Sign = "Ag", Name = "Silver", Molar = 107.9, MeltingPoint = 961.93, BoilingPoint = 2212 },
        new Element { Number = 48, Sign = "Cd", Name = "Cadmium", Molar = 112.41, MeltingPoint = 594.22, BoilingPoint = 1040.0 },
        new Element { Number = 49, Sign = "In", Name = "Indium", Molar = 114.82, MeltingPoint = 429.746, BoilingPoint = 2345.0 },
        new Element { Number = 50, Sign = "Sn", Name = "Tin", Molar = 118.71, MeltingPoint = 505.08, BoilingPoint = 2875.0 },
        new Element { Number = 51, Sign = "Sb", Name = "Antimony", Molar = 121.76, MeltingPoint = 903.78, BoilingPoint = 1825.0 },
        new Element { Number = 52, Sign = "Te", Name = "Tellurium", Molar = 127.60, MeltingPoint = 722.66, BoilingPoint = 1261.0 },
        new Element { Number = 53, Sign = "I", Name = "Iodine", Molar = 126.90, MeltingPoint = 386.85, BoilingPoint = 457.4 },
        new Element { Number = 54, Sign = "Xe", Name = "Xenon", Molar = 131.29, MeltingPoint = 161.3, BoilingPoint = 165.03 },
        new Element { Number = 55, Sign = "Cs", Name = "Cesium", Molar = 132.91, MeltingPoint = 301.59, BoilingPoint = 944.0 },
        new Element { Number = 56, Sign = "Ba", Name = "Barium", Molar = 137.33, MeltingPoint = 1000.0, BoilingPoint = 2170.0 },
        new Element { Number = 57, Sign = "La", Name = "Lanthanum", Molar = 138.90547, MeltingPoint = 920, BoilingPoint = 3469 },
        new Element { Number = 58, Sign = "Ce", Name = "Cerium", Molar = 140.116, MeltingPoint = 795, BoilingPoint = 3443 },
        new Element { Number = 59, Sign = "Pr", Name = "Praseodymium", Molar = 140.90765, MeltingPoint = 931, BoilingPoint = 3257 },
        new Element { Number = 60, Sign = "Nd", Name = "Neodymium", Molar = 144.242, MeltingPoint = 1024, BoilingPoint = 3127 },
        new Element { Number = 61, Sign = "Pm", Name = "Promethium", Molar = 145, MeltingPoint = 1100, BoilingPoint = 3000 },
        new Element { Number = 62, Sign = "Sm", Name = "Samarium", Molar = 150.36, MeltingPoint = 1072, BoilingPoint = 1794 },
        new Element { Number = 63, Sign = "Eu", Name = "Europium", Molar = 151.964, MeltingPoint = 822, BoilingPoint = 1597 },
        new Element { Number = 64, Sign = "Gd", Name = "Gadolinium", Molar = 157.25, MeltingPoint = 1311, BoilingPoint = 3233 },
        new Element { Number = 65, Sign = "Tb", Name = "Terbium", Molar = 158.9254, MeltingPoint = 1356, BoilingPoint = 3230 },
        new Element { Number = 66, Sign = "Dy", Name = "Dysprosium", Molar = 162.5, MeltingPoint = 1412, BoilingPoint = 2562 },
        new Element { Number = 67, Sign = "Ho", Name = "Holmium", Molar = 164.9304, MeltingPoint = 1470, BoilingPoint = 2720 },
        new Element { Number = 68, Sign = "Er", Name = "Erbium", Molar = 167.259, MeltingPoint = 1522, BoilingPoint = 2868 },
        new Element { Number = 69, Sign = "Tm", Name = "Thulium", Molar = 168.9342, MeltingPoint = 1545, BoilingPoint = 1950 },
        new Element { Number = 70, Sign = "Yb", Name = "Ytterbium", Molar = 173.04, MeltingPoint = 824, BoilingPoint = 1466 },
        new Element { Number = 71, Sign = "Lu", Name = "Lutetium", Molar = 175.0, MeltingPoint = 1652, BoilingPoint = 3402 },
        new Element { Number = 72, Sign = "Hf", Name = "Hafnium", Molar = 178.49, MeltingPoint = 2150, BoilingPoint = 5400 },
        new Element { Number = 73, Sign = "Ta", Name = "Tantalum", Molar = 180.9479, MeltingPoint = 2996, BoilingPoint = 5425 },
        new Element { Number = 74, Sign = "W", Name = "Tungsten", Molar = 183.84, MeltingPoint = 3695.0, BoilingPoint = 5828.0},
        new Element { Number = 75, Sign = "Re", Name = "Rhenium", Molar = 186.21, MeltingPoint = 3459.0, BoilingPoint = 5869.0},
        new Element { Number = 76, Sign = "Os", Name = "Osmium", Molar = 190.23, MeltingPoint = 3033.0, BoilingPoint = 5285.0},
        new Element { Number = 77, Sign = "Ir", Name = "Iridium", Molar = 192.22, MeltingPoint = 2410.0, BoilingPoint = 4428.0},
        new Element { Number = 78, Sign = "Pt", Name = "Platinum", Molar = 195.08, MeltingPoint = 1768.3, BoilingPoint = 3825.0},
        new Element { Number = 79, Sign = "Au", Name = "Gold", Molar = 197.0, MeltingPoint = 1064.0, BoilingPoint = 2856.0},
        new Element { Number = 80, Sign = "Hg", Name = "Mercury", Molar = 200.59, MeltingPoint = -38.87, BoilingPoint = 356.0},
        new Element { Number = 81, Sign = "Tl", Name = "Thallium", Molar = 204.38, MeltingPoint = 304.0, BoilingPoint = 1473.0},
        new Element { Number = 82, Sign = "Pb", Name = "Lead", Molar = 207.2, MeltingPoint = 327.46, BoilingPoint = 1750.0},
        new Element { Number = 83, Sign = "Bi", Name = "Bismuth", Molar = 208.98, MeltingPoint = 271.3, BoilingPoint = 1560.0},
        new Element { Number = 84, Sign = "Po", Name = "Polonium", Molar = 209, MeltingPoint = 254, BoilingPoint = 962 },
        new Element { Number = 85, Sign = "At", Name = "Astatine", Molar = 210, MeltingPoint = 302, BoilingPoint = 337 },
        new Element { Number = 86, Sign = "Rn", Name = "Radon", Molar = 222, MeltingPoint = 202, BoilingPoint = 211.3 },
        new Element { Number = 87, Sign = "Fr", Name = "Francium", Molar = 223, MeltingPoint = 27, BoilingPoint = 677 },
        new Element { Number = 88, Sign = "Ra", Name = "Radium", Molar = 226, MeltingPoint = 700, BoilingPoint = 1737 },
        new Element { Number = 89, Sign = "Ac", Name = "Actinium", Molar = 227, MeltingPoint = 1050, BoilingPoint = 3200 },
        new Element { Number = 90, Sign = "Th", Name = "Thorium", Molar = 232.04, MeltingPoint = 1750, BoilingPoint = 4820 },
        new Element { Number = 91, Sign = "Pa", Name = "Protactinium", Molar = 231.0359, MeltingPoint = 1572, BoilingPoint = 4027 },
        new Element { Number = 92, Sign = "U", Name = "Uranium", Molar = 238.03, MeltingPoint = 1405.3, BoilingPoint = 4404 },
        new Element { Number = 93, Sign = "Np", Name = "Neptunium", Molar = 237.0, MeltingPoint = 912.0, BoilingPoint = 4175.0 },
        new Element { Number = 94, Sign = "Pu", Name = "Plutonium", Molar = 244.0, MeltingPoint = 640.0, BoilingPoint = 3232.0 },
        new Element { Number = 95, Sign = "Am", Name = "Americium", Molar = 243.0, MeltingPoint = 994.0, BoilingPoint = 2607.0 },
        new Element { Number = 96, Sign = "Cm", Name = "Curium", Molar= 247.0, MeltingPoint = 1340.0, BoilingPoint = 3110.0 },
        new Element { Number = 97, Sign = "Bk", Name = "Berkelium", Molar = 247.0, MeltingPoint = 1259.0, BoilingPoint = 2900.0 },
        new Element { Number = 98, Sign = "Cf", Name = "Californium", Molar = 251.0, MeltingPoint = 900.0, BoilingPoint = 1470.0 },
        new Element { Number = 99, Sign = "Es", Name = "Einsteinium", Molar = 252.0, MeltingPoint = 860.0, BoilingPoint = 1529.0 }
      };

      return ret;
    }
  }
  //サンプル：new Element { Name = "Hydrogen", MeltingPoint = -259.14, BoilingPoint = -252.87 },

  [AttributeUsage(AttributeTargets.Property)]
  public class CheckMeltByBoilAttribute : ValidationAttribute
  {
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      var model = validationContext.ObjectInstance as Element;
      if (model is null || value is null)
      {
        throw new NullReferenceException();
      }

      if ((double)value <= model.BoilingPoint)
      {
        return ValidationResult.Success;
      }
      else
      {
        return new ValidationResult(null);
      }
    }
  }

  [AttributeUsage(AttributeTargets.Property)]
  public class CheckBoilByMeltAttribute : ValidationAttribute
  {
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      var model = validationContext.ObjectInstance as Element;
      if (model is null || value is null)
      {
        throw new NullReferenceException();
      }

      if (model.MeltingPoint <= (double)value)
      {
        return ValidationResult.Success;
      }
      else
      {
        return new ValidationResult(null);
      }
    }
  }
}
