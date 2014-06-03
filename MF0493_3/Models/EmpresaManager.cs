using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MF0493_3.Models
{
    public class EmpresaManager
    {

        public static empresa get(string nif)
        {
            using (MySQLEntities db = new MySQLEntities())
            {
                var data = from empresa in db.empresas
                           where empresa.nif == nif
                           select empresa;

                if (data.Count() == 0) return null;
                else return data.First();
            }
        }
        public static List<empresa> getAll()
        {
            using (MySQLEntities db = new MySQLEntities())
            {
                var data = from empresa in db.empresas                           
                           select empresa;
                
                return data.ToList();
            }
        }
        public static bool Nueva(empresa emp)
        {
            if (emp == null) return false;

            using (MySQLEntities db = new MySQLEntities())
            {
                var data = from empresa in db.empresas
                           where empresa.nif == emp.nif
                           select empresa;

                if (data.Count() == 0)
                {
                    db.empresas.Add(emp);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }  
        }
        public static bool Modificar(empresa emp)
        {
            if (emp == null) return false;

            using (MySQLEntities db = new MySQLEntities())
            {
                var data = from empresa in db.empresas
                           where empresa.nif == emp.nif
                           select empresa;

                if (data.Count() == 0)
                {
                    db.empresas.Add(emp);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    empresa e = data.First();

                    e.nombre = emp.nombre;
                    e.poblacion = emp.poblacion;
                    e.telefono = emp.telefono;
                    e.logo = emp.logo;
                    e.activa = emp.activa;
                    e.email = emp.email;
                    db.SaveChanges();
                    return true;
                }
            } 
        }
        public static bool Eliminar(string nif)
        {
            using (MySQLEntities db = new MySQLEntities())
            {
                var data = from empresa in db.empresas
                           where empresa.nif == nif
                           select empresa;

                if (data.Count() != 0)
                {
                    db.empresas.Remove(data.First());
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }  
        }
    }
}