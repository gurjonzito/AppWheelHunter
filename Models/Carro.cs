using SQLite;

namespace AppWheelHunter.Models
{
    public class Carro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string DirImagem { get; set; }
        public string Modelo { get; set; }
        public string Lote { get; set; }
        public int Ano { get; set; }
        public bool Obtido { get; set; }
        public bool Desejado { get; set; }
        public string ImagemObtido => Obtido ? "obtido_on.png" : "obtido_off.png";
        public string ImagemDesejado => Desejado ? "desejado_on.png" : "desejado_off.png";
        public string ImagemExcluir { get; set; }
    }
}
