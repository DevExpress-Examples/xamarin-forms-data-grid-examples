﻿using System.ComponentModel;

namespace DataGrid_CustomAppearance {
    public class ModelObject {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
