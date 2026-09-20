using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.DocumentTypes.Views
{
    public interface IDocumentTypesView
    {
        // Фильтры / состояние UI
        string HeadCode { get; }
        bool DialogMode { get; }

        // Положение / выделение в гриде
        int Row { get; }
        int RowSel { get; }
        IList<int> SelectedRows { get; }

        // Управление обновлением UI
        void BeginUpdate();
        void EndUpdate();

        // Построить дерево (данные уже подготовлены Presenter-ом)
        void BuildTree(IEnumerable<object> treeData);

        // Методы для работы с уровнями/разворачиванием
        int GetDepth();
        void ExpandByLevel(int level);
        void ConfigureLevels(int maxLevel); // View сам создаёт меню пунктов уровней

        // Операции со строкой/узлом (Presenter просит View обновить UI)
        object GetSelectedTreeItem(); // возвращает TreeDocumentType (или null), но тип kept as object to avoid assembly coupling
        DialogResult ShowDocumentTypeDialog(Form form);
        void ReplaceCurrentNode(object documentType); // documentType - GrpcCommonNet.Library.DocumentType.DocumentType
        void InsertChildNode(object documentType);
        void RemoveCurrentNode();
        void RemoveNodesByIds(IEnumerable<int> ids);

        // Утилиты
        void ShowMessage(string text, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK);
        void CloseWithResult(object selectedDocumentType); // когда DialogMode и выбор сделан
    }
}