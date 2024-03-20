using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_vet.Models
{
    public class Medicamento
    {
        public int idMedicamento { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public float dosis { get; set; }
        public int estado { get; set; }
        public Medicamento() { }

        public Medicamento(int idMedicamento, string nombre, string descripcion, float dosis, int estado)
        {
            this.idMedicamento = idMedicamento;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.dosis = dosis;
            this.estado = estado;
        }

        public Medicamento(string nombre, string descripcion, float dosis, int estado)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.dosis = dosis;
            this.estado = estado;
        }

    }
}