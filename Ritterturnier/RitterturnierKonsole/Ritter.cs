﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public class Ritter : Teilnehmer
    {
        public string _rufname {  get; set; }
        public Waffe _waffe { get; set; }
        public Knappe _knappe { get; set; }

        public Ritter(string name, string telefonnummer, string rufname) : base(name, telefonnummer) {
            this._name = name;
            this._telefonnummer = telefonnummer;
            this._rufname = rufname;

            this._waffe = null;
            this._knappe = null;
        }

        // Hinzufuegen eines Knappen zu dem Ritter
        public Ritter AddKnappe(Knappe knappe)
        {
            _knappe = knappe;
            return this;
        }

        // Hinzufuegen einer Waffe zu dem Ritter
        public Ritter AddWaffe(Waffe waffe)
        {
            _waffe = waffe;
            return this;
        }

        public override string ToString()
        {
            //Wenn kein Knappe & Waffe vorhanden ist
            if(_knappe != null && _waffe != null) {
                return base.ToString() + $"Rufname: {_rufname}\n" + _knappe.ToString() + _waffe.ToString();
            }
            if(_knappe == null && _waffe != null) // Wenn nur kein Knappe vorhanden
            {
                return base.ToString() + $"Rufname: {_rufname}\n" + _waffe.ToString();
            }
            if (_knappe == null && _waffe != null) // Wenn nur kein Waffe vorhanden
            {
                return base.ToString() + $"Rufname: {_rufname}\n" + _knappe.ToString();
            }

            return base.ToString() + $"Rufname: {_rufname}\n";
        }

    }
}
