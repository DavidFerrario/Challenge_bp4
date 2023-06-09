using Challeng_BP4.Model;
using Dapper;
using MySql.Data.MySqlClient;


namespace Challeng_BP4.Data.repositorios
{
    public class ClientRepository : IClientRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public ClientRepository(MySQLConfiguration connectionString) 
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection() 
        {
            return new MySqlConnection(_connectionString.ConnetionString);
        }
        public async Task<bool> CreateClient(Client client)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO clients(nombre, apellido, fecha_de_nacimiento, cuit, domicilio, telefono_celular, email) 
                        VALUES(@name, @lastName, @birthdate, @cuit, @adress, @cell_phone, @email)";

            var result = await db.ExecuteAsync(sql, new 
            {client.name, client.lastName, client.birthdate, client.cuit, client.adress, client.cell_phone, client.email });

            return result > 0;
        }

        public async Task<bool> DeleteClient(Client client)
        {
            var db = dbConnection();

            var sql = "DELETE FROM clients WHERE idClientes = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = client.ID });

            return result > 0;
        }

        public Task<IEnumerable<Client>> GetAllClients()
        {
            var db = dbConnection();

            var sql = @" SELECT *
                        FROM clients";

            return db.QueryAsync<Client>(sql, new {});

        }

        public async Task<IEnumerable<Client>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClient(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT idClientes, nombres, apellidos, fecha_de_nacimiento, cuit, domicilio, telefono_celular, email 
                        FROM clients
                        WHERE id = @Id";

            return db.QueryFirstOrDefaultAsync<Client>(sql, new {Id = id});
        }

        public async Task<bool> UpdateClient(Client client)
        {
            var db = dbConnection();

            var sql = @" UPDATE clients
                         SET idClientes=@Id,
                             nombre=@name, 
                             apellido=@lastName, 
                             fecha_de_nacimiento=@birthdate,
                             cuit=@cuit, 
                             domicilio=@adress, 
                             telefono_celular=@cell_phone, 
                             email=@email
                          WHERE id=@Id";

            var result = await db.ExecuteAsync(sql, new
            { client.name, client.lastName, client.birthdate, client.cuit, client.adress, client.cell_phone, client.email });

            return result > 0;
        }
    }
}
