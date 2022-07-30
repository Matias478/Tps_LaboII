using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public enum EClases
    {
        Boxeo=12,
        KickBoxing=15,
        Spinning=20,
        EntrenamientoFuncional=14,
        Karate=16
    }
    public enum EHorarios
    {
        TurnoMañana=11,
        TurnoTarde=18,
        TurnoNoche=21
    }
    public class Cliente
    {
        //static int lastId;
        int id;
        string nombre;
        string apellido;
        long dni;
        long telefono;

        EClases clases;
        EHorarios horarios;

        //static Cliente()
        //{
        //    lastId = 1;
        //}
        public Cliente()
        {
        }
        public Cliente(int id,string nombre,string apellido, long dni,long telefono,EClases clases, EHorarios horarios) :this()
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.telefono = telefono;

            this.clases = clases;
            this.horarios = horarios;
            //id = lastId;
            //lastId++;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public long Dni { get => dni; set => dni = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public EClases Clases { get => clases; set => clases = value; }
        public EHorarios Horarios { get => horarios; set => horarios = value; }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {Id} \nNombre: {Nombre} Apellido: {Apellido}");
            sb.AppendLine($"DNI: {Dni} Telefono: {Telefono}");
            sb.AppendLine($"Clase: {Clases} en {Horarios}");


            return sb.ToString(); 
        }

    }

}
