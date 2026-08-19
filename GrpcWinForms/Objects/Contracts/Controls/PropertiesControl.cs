using C1.Win.FlexGrid;
using GrpcCommonNet.Proto.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contracts.Controls
{
    public partial class PropertiesControl : UserControl
    {
        public PropertiesControl()
        {
            InitializeComponent();
        }

        public void SetTreeNodes(DataNode nodes)
        {
            //smartGridProperies.Cols.Count = 2;
            //smartGridProperies.Cols[0].Caption = "Наименование";
            //smartGridProperies.Cols[1].Caption = "Значение";
            smartGridProperies1.Tree.Column = 1; // Дерево рисуется в первой колонке
            smartGridProperies1.Tree.Style = TreeStyleFlags.SimpleLeaf;
            for (int i = smartGridProperies1.Rows.Count - 1; i >= 0; i--)
                if (i >= smartGridProperies1.Rows.Fixed 
                    && i < smartGridProperies1.Rows.Count - smartGridProperies1.Footers.Descriptions.Count ) 
                    smartGridProperies1.Rows.Remove(i);

            FillTree(new[] { nodes }, 0);
        }

        void FillTree(IEnumerable<DataNode> nodes, int level)
        {
            smartGridProperies1.BeginUpdate();
            foreach (var node in nodes)
            {
                // Добавляем строку
                Row row = smartGridProperies1.Rows.Add();
                row.IsNode = true;
                row.Node.Level = level; // Уровень вложенности

                // Заполняем данные
                smartGridProperies1[row.Index, 1] = node.Name;
                smartGridProperies1[row.Index, 2] = node.Value;

                // Если есть дети — идем глубже
                if (!node.IsLeaf)
                {
                    FillTree(node.Children, level + 1);
                }
            }
            smartGridProperies1.EndUpdate();
        }
    }
}
