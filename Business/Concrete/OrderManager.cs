using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        private IOrderDetailDal _orderDetailDal;
        private ICustomerDal _customerDal;
        private ISellerDal _sellerDal;

        public OrderManager(IOrderDal orderDal, IOrderDetailDal orderDetailDal, ICustomerDal customerDal, ISellerDal sellerDal)
        {
            _orderDal = orderDal;
            _orderDetailDal = orderDetailDal;
            _customerDal = customerDal;
            _sellerDal = sellerDal;
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetAll();
        }

        public Order Get(int id)
        {
            return _orderDal.Get(id);
        }

        public void Add(Order entity)
        {

            if (CheckRequiredDate(entity.OrderDate,entity.RequiredDate))
            {
                _orderDal.Add(entity);
                CheckDiscountIsNotNull(entity.Discount);
            }

            if (CustomerWalletDecrease(entity.OrderID) && SellerWalletIncrease(entity.OrderID))
            {
                Console.WriteLine("Order added");
            }
            else
            {
                Console.WriteLine("Order eklenemdi");
            }
        }
        public void Update(Order entity)
        {
            var existing = _orderDal.Get(entity.OrderID);

            if (existing.CustomerID != entity.CustomerID)
            {
                CustomerWalletDecrease(existing.OrderID);
            }
            else if (existing.SellerID != entity.SellerID)
            {
                SellerWalletIncrease(existing.OrderID);
            }
            
            if (CheckRequiredDate(entity.OrderDate,entity.RequiredDate))
            {
                _orderDal.Update(entity);
                CheckDiscountIsNotNull(entity.Discount);
                Console.WriteLine("Order updated");
            }
            else
            {
                Console.WriteLine("Order güncellenemedi");
            }
        }

        public void Delete(Order entity)
        {
            if (CustomerWalletInrease(entity.OrderID) && SellerWalletDecrease(entity.OrderID))
            {
                _orderDal.Delete(entity);
                Console.WriteLine("Order silindi");
            }
            else
            {
                Console.WriteLine("Order silinemedi");
            }
        }

        public List<OrdersCityDetailDto> SortTotalSalesByCity()
        {
            return _orderDal.SortTotalSalesByCity();
        }

        private bool SellerWalletIncrease(int orderId)
        {
            decimal payment = 0;
            foreach (var orderDetail in _orderDetailDal.GetAll())
            {
                if (orderDetail.OrderID == orderId)
                {
                    payment += orderDetail.Quantity * orderDetail.UnitPrice;
                }
            }

            List<Seller> sellers =  _sellerDal.GetAll();
            for (int i = 0; i < sellers.Count; i++)
            {
                sellers[i].SellerInCome += payment;
                if (_sellerDal.Update(sellers[i]))
                {
                    i++;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private bool CustomerWalletDecrease(int orderId)
        {
            decimal payment = 0;
            foreach (var orderDetail in _orderDetailDal.GetAll())
            {
                if (orderDetail.OrderID == orderId)
                {
                    payment += orderDetail.Quantity * orderDetail.UnitPrice;
                }
            }

            Customer customer = new Customer();
            _customerDal.Get(_orderDal.Get(orderId).CustomerID);
            customer.CustomerWallet -= payment;
            if (_customerDal.Update(customer))
            {
                return true;
            }

            return false;
        }

        private bool CustomerWalletInrease(int orderId)
        {
            decimal payment = 0;
            foreach (var orderDetail in _orderDetailDal.GetAll())
            {
                if (orderDetail.OrderID == orderId)
                {
                    payment += orderDetail.Quantity * orderDetail.UnitPrice;
                }
            }

            Customer customer = new Customer();
            _customerDal.Get(_orderDal.Get(orderId).CustomerID);
            customer.CustomerWallet += payment;
            if (_customerDal.Update(customer))
            {
                return true;
            }

            return false;
        }

        private bool SellerWalletDecrease(int orderId)
        {
            decimal payment = 0;
            foreach (var orderDetail in _orderDetailDal.GetAll())
            {
                if (orderDetail.OrderID == orderId)
                {
                    payment += orderDetail.Quantity * orderDetail.UnitPrice;
                }
            }

            List<Seller> sellers = _sellerDal.GetAll();
            for (int i = 0; i < sellers.Count; i++)
            {
                sellers[i].SellerInCome -= payment;
                if (_sellerDal.Update(sellers[i]))
                {
                    i++;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckRequiredDate(DateTime orderDate, DateTime requiredDate)
        {
            TimeSpan duration = requiredDate - orderDate;
            if (duration.Days <= 7)
            {
                return true;
            }

            return false;
        }

        private void CheckDiscountIsNotNull(int discount)
        {
            if (discount != 0)
            {
                Console.WriteLine($"Tebrikler %{discount} indirimli aldınız ürünü.");
            }
        }
    }
}
