using Microsoft.EntityFrameworkCore;
using OneStore.Context;

namespace OneStore.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }

        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context) { 
                CarrinhoCompraId = carrinhoId 
            };
        }

        public void AdicionarAoCarrinho(Roupa roupa)
        {
            var carrinhoCompraItem = _context.T_CARRINHO_COMPRA_ITENS.SingleOrDefault(
                s => s.Roupa.RoupaId == roupa.RoupaId &&
                s.CarrinhoCompraId == CarrinhoCompraId
            );

            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Roupa = roupa,
                    Quantidade = 1
                };
                _context.T_CARRINHO_COMPRA_ITENS.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public void RemoverDoCarrinho(Roupa roupa)
        {
            var carrinhoCompraItem = _context.T_CARRINHO_COMPRA_ITENS.SingleOrDefault(
                 s => s.Roupa.RoupaId == roupa.RoupaId &&
                 s.CarrinhoCompraId == CarrinhoCompraId
            );

            //var quantidadeLocal = 0;
            if(carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    //quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.T_CARRINHO_COMPRA_ITENS.Remove(carrinhoCompraItem);
                }
            }
     
            _context.SaveChanges();
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItens ?? ( CarrinhoCompraItens = _context.T_CARRINHO_COMPRA_ITENS.Where
                (c => c.CarrinhoCompraId == CarrinhoCompraId).Include(s => s.Roupa).ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.T_CARRINHO_COMPRA_ITENS.Where(c => c.CarrinhoCompraId == CarrinhoCompraId);

            _context.T_CARRINHO_COMPRA_ITENS.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public double GetCarrinhoCompraTotal()
        {
            var total = _context.T_CARRINHO_COMPRA_ITENS
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(x => x.Roupa.RoupaPreco * x.Quantidade).Sum();

            return total;
        }
    }
}
