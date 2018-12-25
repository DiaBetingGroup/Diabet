using HtmlAgilityPack;

namespace Diabet
{
    class MatchMarathon
    {
        static string urlLive = "https://www.marathonbet.by/su/live/";

        double[] koeffs = new double[3];

        public double[] Koeffs { get => koeffs;}

        public void getKoeffs(string idMatch)
        {
            HtmlNodeCollection htmlMatchTableCells = new HtmlWeb().Load(urlLive + idMatch).DocumentNode.SelectNodes("//tr[@data-mutable-id=\"MR1mainRow\"]/td");

            double win1 = double.Parse(htmlMatchTableCells[2].InnerText.Replace(".", ","));
            double draw = double.Parse(htmlMatchTableCells[3].InnerText.Replace(".", ","));
            double win2 = double.Parse(htmlMatchTableCells[4].InnerText.Replace(".", ","));

            this.koeffs = new double[]{win1, draw, win2};
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string matchId = args[0];

            MatchMarathon mb = new MatchMarathon();
            mb.getKoeffs(matchId);

            System.Console.WriteLine("{0} - {1} - {2}", mb.Koeffs[0], mb.Koeffs[1], mb.Koeffs[2]);
        }
    }
}