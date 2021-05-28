using System;

namespace Business.Entidades
{
    public class CategoriaModel
    {
        public CategoriaModel() { }
        public CategoriaModel(string codigo, string descricao) 
        {
            Codigo = codigo;
            Descricao = descricao;
            CriadoEm = DateTime.Now;
        }
             
        public Guid Id { get; set; }
         
        public string Codigo { get; set; }
              
        public string Descricao { get; set; }
            
        public DateTime CriadoEm { get; set; }

        public void UpdateCategoria( string codigo, string descricao)
        {    
            Codigo = codigo;
            Descricao = descricao;            
        }               
    }
}
