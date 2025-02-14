using System.Reflection.Metadata.Ecma335;

namespace orai
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];

			Beolvasas("karakterek.txt", karakterek);

			foreach (var item in karakterek)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine(LegmagasabbEletero(karakterek));;
			Console.WriteLine(AtlagSzint(karakterek));;
			ErossegSzerint(karakterek);
			MagasabbSzintu(karakterek, 3);
			FileMentes(karakterek);
			LegjobbHarom(karakterek);
			Legjobbak(karakterek);
			Csata(karakterek);
		}
		static void Beolvasas(string filenev, List<Karakter> karakterek)
		{
			StreamReader sr = new(filenev);

            sr.ReadLine();

			while (!sr.EndOfStream) 
			{
				string sor = sr.ReadLine();
				string[] szavak = sor.Split(';');

				Karakter karakter = new Karakter(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);
			}
        }

		static Karakter LegmagasabbEletero(List<Karakter> karakterek) {
			Karakter ret = karakterek[0];
			foreach (var karakter in karakterek) {
				if (karakter.Eletero > ret.Eletero) {
					ret = karakter;
				}
			}
			return ret;
		}

		static float AtlagSzint(List<Karakter> karakterek) {
			float ret = 0;
			foreach (var karakter in karakterek) {
				ret += karakter.Szint;
			}
			ret /= karakterek.Count;
			return ret;
		}

		static void ErossegSzerint(List<Karakter> karakterek) {
			var ret = karakterek.OrderByDescending(k => k.Ero);
			Console.WriteLine("Karakterek erősség szerint rendezve:");
            foreach (var karakter in ret)
            {
                Console.WriteLine(karakter);
            }
		}
		static List<Karakter> MagasabbSzintu(List<Karakter> karakterek, int szint) {
            return karakterek.Where(k => k.Szint > szint).ToList();
        }

		static void FileMentes(List<Karakter> karakterek) {
			StreamWriter sw = new("karakterek.csv");
			foreach (var karakter in karakterek) {
				sw.WriteLine(karakter);
			}
			sw.Close();
		}
	
		static List<Karakter> LegjobbHarom(List<Karakter> karakterek) {
			var ret = karakterek.OrderByDescending(k => k.Ero+k.Szint).ToList()[0..3];
			return ret;
		}

		static List<Karakter> Legjobbak(List<Karakter> karakterek) {
			var ret = karakterek.OrderByDescending(k => k.Ero+k.Szint).ToList();
			return ret;
		}

		static void Csata(List<Karakter> karakterek) {
			var team1 = karakterek[..(karakterek.Count/2)];
			var team2 = karakterek[(karakterek.Count/2)..];

			int team1STR = 0;
			int team2STR = 0;
			foreach (var item in team1) {
				team1STR += item.Szint+item.Ero;
			}
			foreach (var item in team1) {
				team2STR += item.Szint+item.Ero;
			}
			if (team1STR > team2STR) {
				System.Console.WriteLine("első csapat nyert");
			}else {
				System.Console.WriteLine("második csapat nyert");
			}
		}
	}
}
