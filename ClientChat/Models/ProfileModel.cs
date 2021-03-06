﻿using Caliburn.Micro;
using SharpChat.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Models
{
    class ProfileModel : PropertyChangedBase
    {
        public IClientManager Manager { get; set; }

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
    }
}
