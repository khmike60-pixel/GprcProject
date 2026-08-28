using C1.Win.FlexGrid;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Proto.Utils;
using SmartLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Contracts.Models
{
    public class TreeContract : ITreeData
    {
        public int Id { get ; set ; }  // node_id
        public int ParentId { get ; set ; } // parent_node_id
        public string Name { get; set; } // 
        public DateTime Date { get; set; }
        public int ContractId { get; set; }
        public DateTime ContractDate { get; set; }
        public string Number {  get; set; }
        public string Seller {  get; set; }
        public string Buyer { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
        public string TypeCode { get; set; }
        public string TypeForm { get; set; }
        public decimal Sum {  get; set; }
        public string Currency { get; set; }
        public decimal Paid { get; set; }
        public decimal Shipped { get; set; }
        public DateTime? DateExpiried {  get; set; }
        public int? Contract_RootId { get; set; }
        public string State {  get; set; }

        public TreeContract FromNodeContract(NodeContract node)
        {
            TreeContract treeContract = new TreeContract()
            {
                Id = node.NodeId,
                ParentId = node.ParentNodeId,
                Name = (node.NodeType == "contract_without_agreements" ? "Контракт" : // Контракт без ДС
                                node.NodeType == "root" ? "Контракт" :                       // Корень контракта с ДС
                                node.NodeType == "agreement" ? "Допсоглашение" :             // ДС
                                node.NodeType == "first_contract" ? "Первичный контракт" :   // Первичный контракт
                                node.NodeType == "frame_root" ? "Рамочный контракт" : "Неизвестно")  // Певичный контракт
                        + " " + node.Contract.Number,
                ContractId = node.Contract.Id,
                ContractDate = node.Contract.Date.ToDateTime(),
                Buyer = node.Contract.Buyer.Name,
                Seller = node.Contract.Seller.Name,
                Date = node.Contract.Date.ToDateTime(),
                Number = node.Contract.Number,
                Currency = node.Contract.Currency.Abbrev,
                DateExpiried = node.Contract.ExpirationDate == null ? null : node.Contract.ExpirationDate.ToDateTime(),
                Paid = 0,
                Shipped = 0,
                Sum = MyConvert.ToDecimal(node.Contract.Sum),
                Type = node.Contract.TypeContract.Name,
                TypeId = node.Contract.TypeContract.Id,
                TypeCode = node.Contract.TypeContract.Code,
                TypeForm = node.Contract.TypeContract.Form,
                Contract_RootId = node.Contract.RootId,
                State = node.Contract.State == 0 ? "" :  // Новый
                                node.Contract.State == 1 ? "+" : // Подписан
                                node.Contract.State == 2 ? ">" : // Есть операции
                                node.Contract.State == 3 ? "=" : // Баланс
                                node.Contract.State == 4 ? "*" : // Завершен
                                "?"
            };
            return treeContract;
        }

        public NodeContract ToNodeContract()
        {
            NodeContract nodeContract = new NodeContract()
            {
                NodeId = this.ContractId * 1000 + 1,
                ParentNodeId = 0,
                NodeType = "contract_without_agreements",
                TreeLevel = 0,
                Contract = new Contract()
                {
                    Id = this.ContractId,
                    RootId = this.ParentId,
                    Buyer = new Contragent() { Name = this.Buyer },
                    Seller = new Contragent() { Name = this.Seller },
                    Number = this.Number,
                    Date = this.Date.ToUniversalTime().ToTimestamp(),
                    Sum = MyConvert.ToDecimalValue(this.Sum, 2),
                    Amount = MyConvert.ToDecimalValue(this.Sum, 2)
                }
            };
            return nodeContract;
        }
    }
}
