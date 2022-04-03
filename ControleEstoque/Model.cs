using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace ControleEstoque1
{
    public class Model
    {
        public void SetUsuario(DtoUsuario u)
        {
            Context db = new Context();

            db.usuario.Add(u);
            db.SaveChanges();
        }

        public void SetProduto(dtoProduto u)
        {
            Context db = new Context();

            db.produto.Add(u);
            db.SaveChanges();
        }



        public void EditUsuario(DtoUsuario u)
        {
            Context db = new Context();
            DtoUsuario e = db.usuario.FirstOrDefault(p => p.id == u.id);
            e.nome = u.nome;
            e.login = u.login;
            e.senha = u.senha;
            
            db.SaveChanges();
        }

        public void EditProduto(dtoProduto u)
        {
            Context db = new Context();
            dtoProduto e = db.produto.FirstOrDefault(p => p.id == u.id);
            e.nome = u.nome;
            e.marca = u.marca;
            e.quantidade = u.quantidade;
            e.preco = u.preco;

            db.SaveChanges();
        }

        public List<DtoUsuario2> ListUsuarios()
        {
            Context db = new Context();
            List<DtoUsuario2> result = (from a in db.usuario
                                  select new DtoUsuario2
                                  {
                                      id = a.id,
                                      nome = a.nome
                                  }).ToList();

            return new List<DtoUsuario2>(result);


        }
       
        public List<DtoProduto2> ListProduto()
        {
            Context db = new Context();
            List<DtoProduto2> result = (from a in db.produto
                                        select new DtoProduto2
                                        {
                                            id = a.id,
                                            nome = a.nome,
                                            
                                        }).ToList();

            return new List<DtoProduto2>(result);


        }

        public DtoUsuario2 GetUsuarioId(int id)
        {
            Context db = new Context();
            var result = (from a in db.usuario
                             where a.id == id
                                   select new DtoUsuario2
                                   {
                                       id = a.id,
                                       nome = a.nome
                                   }).FirstOrDefault();

            var result1 = db.usuario.Where(p => p.id == id).FirstOrDefault();

            return result;
        }

        public DtoProduto2 GetProdutoID(int id)
        {
            Context db = new Context();
            var result = (from a in db.produto
                          where a.id == id
                          select new DtoProduto2
                          {
                              id = a.id,
                              nome = a.nome,
                              
                          }).FirstOrDefault();

            var result1 = db.produto.Where(p => p.id == id).FirstOrDefault();

            return result;
        }

        public void DeletarUsuario(int id)
        {
            Context db = new Context();
            DtoUsuario u = db.usuario.FirstOrDefault(p => p.id == id);
            db.usuario.Remove(u);
            db.SaveChanges();
        }

        public void DeletarProduto(int id)
        {
            Context db = new Context();
            dtoProduto u = db.produto.FirstOrDefault(p => p.id == id);
            db.produto.Remove(u);
            db.SaveChanges();
        }
    }
}
