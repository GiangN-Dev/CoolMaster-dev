using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CoolMaster.Utils
{
    /// <summary>
    /// Generic helper to enable click-to-sort on a DataGridView bound to a list of T.
    /// Usage:
    ///  - var sorter = new DataGridViewSorter<YourDto>(yourGrid);
    ///  - sorter.UpdateItems(listOfItems);
    ///  - Optionally: sorter.SetDefaultSort(nameof(YourDto.Prop), true);
    /// Notes:
    ///  - Columns should have DataPropertyName set to DTO property names.
    ///  - Sorting is client-side (current page). For server-side sorting extend service/repo.
    /// </summary>
    public class DataGridViewSorter<T>
    {
        private readonly DataGridView _grid;
        private List<T> _items = new List<T>();
        private string _sortProperty;
        private bool _sortAscending = true;

        public DataGridViewSorter(DataGridView grid)
        {
            _grid = grid ?? throw new ArgumentNullException(nameof(grid));

            // Ensure columns use Programmatic sort so we control glyph and behavior
            foreach (DataGridViewColumn c in _grid.Columns)
                c.SortMode = DataGridViewColumnSortMode.Programmatic;

            _grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;
        }

        public void UpdateItems(List<T> items)
        {
            _items = items ?? new List<T>();
            ApplySortAndBind();
        }

        public void SetDefaultSort(string propertyName, bool ascending = true)
        {
            _sortProperty = propertyName;
            _sortAscending = ascending;
            ApplySortAndBind();
            UpdateAllGlyphs();
        }

        private void Grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var col = _grid.Columns[e.ColumnIndex];
            var prop = col.DataPropertyName;
            if (string.IsNullOrEmpty(prop)) return;

            if (_sortProperty == prop)
                _sortAscending = !_sortAscending;
            else
            {
                _sortProperty = prop;
                _sortAscending = true;
            }

            ApplySortAndBind();
            UpdateAllGlyphs(col);
        }

        private void ApplySortAndBind()
        {
            if (_items == null) _items = new List<T>();

            if (string.IsNullOrEmpty(_sortProperty))
            {
                _grid.DataSource = new BindingList<T>(_items);
                return;
            }

            var propInfo = typeof(T).GetProperty(_sortProperty, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (propInfo == null)
            {
                _grid.DataSource = new BindingList<T>(_items);
                return;
            }

            try
            {
                IEnumerable<T> sorted;
                if (_sortAscending)
                    sorted = _items.OrderBy(x => propInfo.GetValue(x, null));
                else
                    sorted = _items.OrderByDescending(x => propInfo.GetValue(x, null));

                _grid.DataSource = new BindingList<T>(sorted.ToList());
            }
            catch
            {
                // fallback: if comparison fails, bind original list
                _grid.DataSource = new BindingList<T>(_items);
            }
        }

        private void UpdateAllGlyphs(DataGridViewColumn active = null)
        {
            foreach (DataGridViewColumn c in _grid.Columns)
                c.HeaderCell.SortGlyphDirection = SortOrder.None;

            if (active != null)
                active.HeaderCell.SortGlyphDirection = _sortAscending ? SortOrder.Ascending : SortOrder.Descending;
        }
    }
}
