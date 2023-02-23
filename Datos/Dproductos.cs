using System.Data;
using System.Data.SqlClient;
using Tiendaapi.Conexion;
using Tiendaapi.Modelo;

namespace Tiendaapi.Datos
{
    public class Dproductos : Mproducto
    {
        Conexionbd cn = new Conexionbd();
        public async Task<List<Mproducto>> Mostrarproductos()
        {
            var lista = new List<Mproducto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproducto = new Mproducto();
                            mproducto.IdProducto = (int)item["IdProducto"];
                            mproducto.Descripcion = (string)item["Descripcion"];
                            mproducto.Precio = (decimal)item["Precio"];
                            lista.Add(mproducto);
                        }
                    }
                }


            }
            return lista;
        }

        public async Task<List<Mproducto>> MostrarproductoPorId(Mproducto parametros)
        {
            var lista = new List<Mproducto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProductoPorId", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproducto = new Mproducto();
                            mproducto.IdProducto = (int)item["IdProducto"];
                            mproducto.Descripcion = (string)item["Descripcion"];
                            mproducto.Precio = (decimal)item["Precio"];
                            lista.Add(mproducto);
                        }
                    }
                }
            }
            return lista;
        }


        public async Task Insertarproductos(Mproducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descripcion", parametros.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", parametros.Precio);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task Editarproductos(Mproducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    cmd.Parameters.AddWithValue("@Precio", parametros.Precio);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }

            }
        }

        public async Task Eliminarproductos(Mproducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }

            }
        }

    }
}

