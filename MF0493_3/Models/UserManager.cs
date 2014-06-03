using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MF0493_3.Models
{
    public class UserManager
    {

        public static usuario get(string username)
        {
            MySQLEntities db = new MySQLEntities();
            var data = from usuarios in db.usuarios
                       where usuarios.username == username
                       select usuarios;

            if (data.Count() == 0) return null;
            else return data.First();

        }
        public static List<usuario> getAll()
        {
            using (MySQLEntities db = new MySQLEntities())
            {
                var data = from usuarios in db.usuarios
                           select usuarios;

                return data.ToList();
            }
        }

        public static bool NuevoUsuario(usuario u) {

            if (u == null) return false;

            using (MySQLEntities db = new MySQLEntities())
            {
                var data = from usuarios in db.usuarios
                           where usuarios.username == u.username
                           select usuarios;

                if (data.Count() == 0)
                {
                    db.usuarios.Add(u);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }            
        }
        public static void CrearAdmin()
        {
            using (MySQLEntities db = new MySQLEntities())
            {
                var data = from usuarios in db.usuarios
                           where usuarios.username == "admin"
                           select usuarios;

                if (data.Count() == 0)
                {
                    usuario u = new usuario() 
                    { 
                        username = "admin",
                        activo = true,
                        email ="jucles@a2000.es",                        
                        passwdSinCifrar = "aaa111..."
                    };                    
                    db.usuarios.Add(u);
                    db.SaveChanges();                    
                }
            }      

        }

    }
}