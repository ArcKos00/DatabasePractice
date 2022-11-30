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

        public async Task Start()
        {
            var category1 = await _category.AddCategotyAsync("Socks", "Sample", new List<Product>(), true);
            var customer1 = await _customer.AddCustomerAsync("st.Shevchenko", "sampla@ukr.net", "Volod'ka", "Zelensky", "+380004245324", "KVN95", new List<Order>());
            var shipper1 = await _shipper.AddShipperAsync("Vasyl", "+38094949492", new List<Order>());
            var order1 = await _order.AddOrderAsync(new Customer(), new List<OrderDetail>(), new Shipper(), new Payment(), 1);
            var product1 = await _product.AddProductAsync("Socks", "Nice Socks from Zhitomir", new Supplier(), new Category(), 20f, 30f, new List<OrderDetail>());
            var supplier1 = await _supplier.AddSupplierAsync("SomeCompany", "Peter", "+380884834843", "bebka@ukr.net", new List<Product>());

            var product2 = await _product.AddProductAsync("Water", "Water from Mirgorod", new Supplier(), new Category(), 30f, 0, new List<OrderDetail>());
            var category2 = await _category.AddCategotyAsync("Water", "Nice Water", new List<Product>(), true);

            // Update Order
            var order = await _order.GetOrderASync(order1) !;
            if (order != null)
            {
                var payment1 = await _payment.AddPaymentAsync("card", new List<Order>() { order });
                order.Payment = await _payment.GetPaymentAsync(payment1) !;
                await _order.UpdateOrder(order1, order);
            }

            // Update products in first Category
            var category1Obj = await _category.GetCategoryAsync(category1) !;
            if (category1Obj != null)
            {
                var product1Obj = await _product.GetProductAsync(product1) !;
                var products = new List<Product>(category1Obj.Products!) { product1Obj! };
                category1Obj.Products = products;
                await _category.UpdateCategoryAsync(category1, category1Obj);
            }

            // Update products in second Category
            var category2Obj = await _category.GetCategoryAsync(category2) !;
            if (category2Obj != null)
            {
                var product1Obj = await _product.GetProductAsync(product1) !;
                var products = new List<Product>(category2Obj.Products!) { product1Obj! };
                category2Obj.Products = products;
                await _category.UpdateCategoryAsync(category2, category2Obj);
            }

            // Getting a list product categories
            var categories = await _product.GetCategoryListAsync(product1);
            foreach (var category in categories!)
            {
                Console.WriteLine(category);
            }
        }
    }
}
