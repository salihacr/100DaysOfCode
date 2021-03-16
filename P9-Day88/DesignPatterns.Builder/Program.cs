using System;

namespace DesignPatterns.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            YemekBuilder builder = new SuluYemekConcreteBuilder();
            YemekYapici yemekYapici = new YemekYapici();
            yemekYapici.YemekYap(builder);
            builder.Yemek.ToString();

            builder = new EtliYemekConcreteBuilder();
            yemekYapici.YemekYap(builder);
            builder.Yemek.ToString();

            Console.ReadKey();
        }
    }
    enum YemekTipi
    {
        Sulu,
        Etli,
        Sebzeli
    }
    // Product
    class Yemek
    {
        public YemekTipi YemekTipi { get; set; }
        public string YemekAdi { get; set; }
        public double Tuz { get; set; }
        public override string ToString()
        {
            Console.WriteLine($"{YemekTipi} -> Tuz Oranı : {Tuz}");
            return base.ToString();
        }
    }
    //Builder Class
    abstract class YemekBuilder
    {
        protected Yemek yemek;

        public Yemek Yemek
        {
            get
            {
                return yemek;
            }
        }
        abstract public void SetYemekTipi();
        abstract public void SetYemekAdi();
        abstract public void SetTuz();
    }
    // Concrete Builder Classes
    class SuluYemekConcreteBuilder : YemekBuilder
    {
        public SuluYemekConcreteBuilder()
        {
            yemek = new Yemek();
        }
        public override void SetTuz() => yemek.Tuz = 75;

        public override void SetYemekAdi() => yemek.YemekAdi = "Çorba";

        public override void SetYemekTipi() => yemek.YemekTipi = YemekTipi.Sulu;
    }
    class EtliYemekConcreteBuilder : YemekBuilder
    {
        public EtliYemekConcreteBuilder()
        {
            yemek = new Yemek();
        }
        public override void SetTuz() => yemek.Tuz = 65;

        public override void SetYemekAdi() => yemek.YemekAdi = "Etli Pilav";

        public override void SetYemekTipi() => yemek.YemekTipi = YemekTipi.Etli;
    }
    class SebzeliYemekConcreteBuilder : YemekBuilder
    {
        public SebzeliYemekConcreteBuilder()
        {
            yemek = new Yemek();
        }
        public override void SetTuz() => yemek.Tuz = 15;

        public override void SetYemekAdi() => yemek.YemekAdi = "Ispanak";

        public override void SetYemekTipi() => yemek.YemekTipi = YemekTipi.Sebzeli;
    }

    // Director class
    class YemekYapici
    {
        public void YemekYap(YemekBuilder builder)
        {
            builder.SetTuz();
            builder.SetYemekAdi();
            builder.SetYemekTipi();
        }
    }
}
