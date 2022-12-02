using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;
using DatabaseMigrations.Services.Abstractions;

namespace DatabaseMigrations
{
    public class Application
    {
        private readonly ICategoryService _category;
        private readonly ICustomerService _customer;
        private readonly IOrderService _order;
        private readonly IOrderDetailService _orderDetails;
        private readonly IPaymentService _payment;
        private readonly IProductService _product;
        private readonly IShipperService _shipper;
        private readonly ISupplierService _supplier;

        public Application(
            ICategoryService category,
            ICustomerService customer,
            IOrderService order,
            IOrderDetailService orderDetails,
            IPaymentService payment,
            IProductService product,
            IShipperService shipper,
            ISupplierService supplier)
        {
            _category = category;
            _customer = customer;
            _order = order;
            _orderDetails = orderDetails;
            _payment = payment;
            _product = product;
            _shipper = shipper;
            _supplier = supplier;
        }

        public void Start()
        {
        }
    }
}
