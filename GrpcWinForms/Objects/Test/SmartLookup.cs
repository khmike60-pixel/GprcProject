using C1.Win.Input;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GrpcWinForms.Objects.Test
{
    public partial class SmartLookup : UserControl
    {
        private readonly LookupPopupForm _popup;

        private CancellationTokenSource _cts;

        private bool _popupVisible;

        private int _selectedIndex = -1;

        private List<LookupItem> _items = new();

        public event EventHandler<LookupItem> ValueSelected;

        public ISmartLookupDataProvider<LookupItem> DataProvider { get; set; }

        public SmartLookup()
        {
            InitializeComponent();

            _popup = new LookupPopupForm();
            
            WireEvents();
        }

        private void WireEvents()
        {
            _button.Click += Button_Click;

            _textBox.TextChanged += TextBox_TextChanged;
            _textBox.KeyDown += TextBox_KeyDown;

            _popup.Grid.DoubleClick += Grid_DoubleClick;
            _popup.Grid.KeyDown += Grid_KeyDown;

        }

        private async void TextBox_TextChanged(object? sender, EventArgs e)
        {
            string text = _textBox.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                HidePopup();
                return;
            }

            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(300, _cts.Token);

                List<LookupItem> items =
                    await DataProvider.SearchAsync(text);

                if (_cts.IsCancellationRequested)
                    return;

                _items = items;

                ShowResults(items);
            }
            catch
            {
            }
        }

        private void ShowResults(List<LookupItem> items)
        {
            var grid = _popup.Grid;

            _popup.Grid.Rows.Count = 1;

            foreach (var item in items)
            {
                int row = _popup.Grid.Rows.Count;

                _popup.Grid.Rows.Count++;

                _popup.Grid[row, 0] = item.DisplayText;
            }

            if (items.Count == 0)
            {
                HidePopup();
                return;
            }

            ShowPopup();
        }

        private void ShowPopup()
        {
            if (_popupVisible)
                return;

            Point screen = Parent.PointToScreen(Location);

            _popup.Location =
                new Point(screen.X, screen.Y + Height);

            _popup.Width = Width;
            _popup.Height = 250;

            _popup.Show();

            _popupVisible = true;
        }

        private void HidePopup()
        {
            _popup.Hide();

            _popup.Hide();

            _selectedIndex = -1;
        }

        private void TextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (!_popupVisible)
                    return;

            switch (e.KeyCode)
            {
                case Keys.Down:
                    MoveSelection(1);
                    e.Handled = true;
                    break;

                case Keys.Up:
                    MoveSelection(-1);
                    e.Handled = true;
                    break;

                case Keys.Enter:
                    AcceptSelection();
                    e.Handled = true;
                    break;

                case Keys.Escape:
                    HidePopup();
                    e.Handled = true;
                    break;
            }
        }

        private void MoveSelection(int delta)
        {
            if (_items.Count == 0)
                return;

            _selectedIndex += delta;

            if (_selectedIndex < 0)
                _selectedIndex = 0;

            if (_selectedIndex >= _items.Count)
                _selectedIndex = _items.Count - 1;

            _popup.Grid.Row = _selectedIndex + 1;
        }

        private void AcceptSelection()
        {
            if (_selectedIndex < 0)
                return;

            LookupItem item = _items[_selectedIndex];

            _textBox.Text = item.DisplayText;

            HidePopup();

            ValueSelected?.Invoke(this, item);
        }

        private void Grid_DoubleClick(object? sender, EventArgs e)
        {
            _selectedIndex = _popup.Grid.Row - 1;

            AcceptSelection();
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            if (_popupVisible)
                HidePopup();
            else
                ShowPopup();
        }

        private void Grid_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    AcceptSelection();
                    e.Handled = true;
                    break;
                case Keys.Escape:
                    HidePopup();
                    e.Handled = true;
                    break;
            }
        }
    }
}
