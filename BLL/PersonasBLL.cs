using Microsoft.EntityFrameworkCore;
using RegistroPersona.DAL;
using RegistroPersona.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroPersona.BLL {
    public class PersonasBLL {

		public static bool Guardar(Persona persona) {
			bool paso = false;

			Contexto db = new Contexto();

			try {

				db.Personas.Add(persona);
				paso = (db.SaveChanges() > 0);

			} catch (Exception) {

				throw;

			} finally {
				db.Dispose();
			}

			return paso;
		}
		public static Persona Buscar(int personaId) {

			Contexto db = new Contexto();
			Persona persona = new Persona();

			try {

				persona = db.Personas.Find(personaId);

			} catch (Exception) {

				throw;

			} finally {
				db.Dispose();
			}

			return persona;
		}
		public static bool Eliminar(int personaId) {
			bool paso = false;

			Contexto db = new Contexto();


			try {

				var persona = db.Personas.Find(personaId);
				if (persona != null) {
					db.Entry(persona).State = EntityState.Deleted;
					paso = (db.SaveChanges() > 0);
				}

			} catch (Exception) {

				throw;

			} finally {
				db.Dispose();
			}

			return paso;
		}
		public static bool Modificar(Persona persona) {
			bool paso = false;

			Contexto db = new Contexto();

			try {

				db.Entry(persona).State = EntityState.Modified;
				paso = (db.SaveChanges() > 0);

			} catch (Exception) {

				throw;

			} finally {
				db.Dispose();
			}

			return paso;
		}

		public static List<Persona> GetList(Expression<Func<Persona , bool>> expression) {

			List<Persona> personasList = new List<Persona>();
			Contexto db = new Contexto();

			try {

				personasList = db.Personas.Where(expression).ToList();

			} catch (Exception) {

				throw;
			} finally {
				db.Dispose();
			}

			return personasList;
		}

	}
}
