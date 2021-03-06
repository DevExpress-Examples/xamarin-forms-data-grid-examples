﻿using System;
using Xamarin.Forms;
using DevExpress.XamarinForms.DataGrid;

namespace DataGrid_ValidateCellEvent {
    public partial class MainPage : ContentPage {
        public MainPage() {
            DevExpress.XamarinForms.DataGrid.Initializer.Init();
            InitializeComponent();
        }

        private void Grid_Tap(object sender, DataGridGestureEventArgs e) {
            if (e.Item != null) {
                var editForm = new EditFormPage(grid, grid.GetItem(e.RowHandle));
                editForm.ValidateCell += EditForm_ValidateCell;
                Navigation.PushAsync(editForm);
            }
        }

        private void EditForm_ValidateCell(object sender, DataGridValidationEventArgs e) {
            if (e.FieldName == "Quantity" && (decimal)e.NewValue <= 0) {
                e.ErrorContent = "The value must be positive.";
            }
            else if (e.FieldName == "Date" && (DateTime)e.NewValue > DateTime.Now.Date)
                e.ErrorContent = "The date value cannot be in the future.";
        }
    }
}
