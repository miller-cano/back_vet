using back_vet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace back_vet.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class MedicamentoController : ApiController
    {
        // GET: api/Medicamento
        public IEnumerable<Medicamento> Get()
        {
            GestorMedicamento gMedicamento = new GestorMedicamento();
            return gMedicamento.getMedicamento();
        }

        // GET: api/Medicamento/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Medicamento
        public bool Post([FromBody]Medicamento medicamento)
        {
            GestorMedicamento gMedicamento = new GestorMedicamento();
            bool res = gMedicamento.addMedicamento(medicamento);
            return res;
        }

        // PUT: api/Medicamento/5
        public bool Put(int id, [FromBody]Medicamento medicamento)
        {
            GestorMedicamento gMedicamento = new GestorMedicamento();
            bool res = gMedicamento.updateMedicamento(id, medicamento);
            return res;
        }

        // DELETE(Inactivo): api/Medicamento/5
        public bool Delete(int id)
        {
            GestorMedicamento gMedicamento = new GestorMedicamento();
            bool res = gMedicamento.estadoMedicamento(id, 0);
            return res;
        }

        // DELETE(Tabla): api/Medicamento/5
       /* public bool DeleteT(int id)
        {
            GestorMedicamento gMedicamento = new GestorMedicamento();
            bool res = gMedicamento.deleteMedicamento(id);
            return res;
        }*/
    }
}
