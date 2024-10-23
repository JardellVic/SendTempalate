using Npgsql;

namespace CRM.Conexao
{
    internal class conexaoCRM
    {
        
        private const string connectionString = "Host=172.16.1.103;Port=5432;Username=jvsilva;Password=1011;Database=crm";

        public string VerificarCredenciais(string login, string senha)
        {
            string username = null;

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT username FROM usuarios WHERE login = @login AND senha = @senha";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@senha", senha);

                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            username = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao conectar ao banco de dados: {ex.Message}");
            }

            return username;
        }

        public string GetDatabaseVersion()
        {
            string dbVersion = string.Empty;

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT version FROM version LIMIT 1";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        dbVersion = result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao conectar ao banco de dados: {ex.Message}");
            }

            return dbVersion;
        }

        public void AtualizarExecucao(string coluna)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string[] colunasPermitidas = { "antiparasitario", "suplemento", "vermifugo", "racao", "welcome", "vacina", "milteforan" };

                    if (Array.Exists(colunasPermitidas, c => c == coluna.ToLower()))
                    {
                        string query = $"UPDATE controle_execucao SET {coluna} = TRUE WHERE \"data\" = @data";

                        using (var command = new NpgsqlCommand(query, connection))
                        {
                            DateTime dataAtual = DateTime.Now.Date;
                            command.Parameters.AddWithValue("@data", dataAtual);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"A coluna '{coluna}' foi atualizada para TRUE para a data {dataAtual.ToShortDateString()}.");
                            }
                            else
                            {
                                Console.WriteLine("Nenhuma linha foi atualizada.");
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Coluna inválida. As colunas permitidas são: antiparasitario, suplemento, vermifugo, racao, welcome, vacina, milteforan.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar a coluna: {ex.Message}");
            }
        }

        public void AtualizarExecucaoVerificar(string coluna)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string[] colunasPermitidas = { "antiparasitario", "suplemento", "vermifugo", "racao", "welcome", "vacina", "milteforan" };

                    if (Array.Exists(colunasPermitidas, c => c == coluna.ToLower()))
                    {
                        string query = $"UPDATE controle_execucao_verificar SET {coluna} = TRUE WHERE \"data\" = @data";

                        using (var command = new NpgsqlCommand(query, connection))
                        {
                            DateTime dataAtual = DateTime.Now.Date;
                            command.Parameters.AddWithValue("@data", dataAtual);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"A coluna '{coluna}' foi atualizada para TRUE para a data {dataAtual.ToShortDateString()}.");
                            }
                            else
                            {
                                Console.WriteLine("Nenhuma linha foi atualizada.");
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Coluna inválida. As colunas permitidas são: antiparasitario, suplemento, vermifugo, racao, welcome, vacina, milteforan.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar a coluna: {ex.Message}");
            }
        }

        public void InserirControleExecucao(string usuario)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = @"SELECT COUNT(*) FROM controle_execucao WHERE ""data"" = @data";
                    using (var checkCommand = new NpgsqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@data", DateTime.Now.Date);

                        long count = (long)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            return;
                        }
                    }

                    string insertQuery = @"
                INSERT INTO controle_execucao (""data"", antiparasitario, suplemento, vermifugo, racao, welcome, vacina, milteforan, usuario)
                VALUES (@data, false, false, false, false, false, false, false, @usuario)";

                    using (var insertCommand = new NpgsqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@data", DateTime.Now.Date);
                        insertCommand.Parameters.AddWithValue("@usuario", usuario);

                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir controle de execução: {ex.Message}");
            }
        }

        public void InserirControleExecucaoVerificar(string usuario)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = @"SELECT COUNT(*) FROM controle_execucao_verificar WHERE ""data"" = @data";
                    using (var checkCommand = new NpgsqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@data", DateTime.Now.Date);

                        long count = (long)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            return;
                        }
                    }

                    string insertQuery = @"
                INSERT INTO controle_execucao_verificar (""data"", antiparasitario, suplemento, vermifugo, racao, welcome, vacina, milteforan, usuario)
                VALUES (@data, false, false, false, false, false, false, false, @usuario)";

                    using (var insertCommand = new NpgsqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@data", DateTime.Now.Date);
                        insertCommand.Parameters.AddWithValue("@usuario", usuario);

                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir controle de execução: {ex.Message}");
            }
        }

        public ControleExecucao ObterControleExecucaoGerar()
        {
            ControleExecucao controle = null;

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT \"data\", antiparasitario, suplemento, vermifugo, racao, welcome, vacina, milteforan, usuario " +
                                   "FROM controle_execucao WHERE \"data\" = @data";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@data", DateTime.Now.Date);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                controle = new ControleExecucao
                                {
                                    Data = reader.GetDateTime(0),
                                    Antiparasitario = reader.GetBoolean(1),
                                    Suplemento = reader.GetBoolean(2),
                                    Vermifugo = reader.GetBoolean(3),
                                    Racao = reader.GetBoolean(4),
                                    Welcome = reader.GetBoolean(5),
                                    Vacina = reader.GetBoolean(6),
                                    Milteforan = reader.GetBoolean(7),
                                    Usuario = reader.GetString(8)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter controle de execução: {ex.Message}");
            }

            return controle;
        }

        public ControleExecucao ObterControleExecucaoVerificar()
        {
            ControleExecucao controle = null;

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT \"data\", antiparasitario, suplemento, vermifugo, racao, welcome, vacina, milteforan, usuario " +
                                   "FROM controle_execucao_verificar WHERE \"data\" = @data";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@data", DateTime.Now.Date);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                controle = new ControleExecucao
                                {
                                    Data = reader.GetDateTime(0),
                                    Antiparasitario = reader.GetBoolean(1),
                                    Suplemento = reader.GetBoolean(2),
                                    Vermifugo = reader.GetBoolean(3),
                                    Racao = reader.GetBoolean(4),
                                    Welcome = reader.GetBoolean(5),
                                    Vacina = reader.GetBoolean(6),
                                    Milteforan = reader.GetBoolean(7),
                                    Usuario = reader.GetString(8)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter controle de execução: {ex.Message}");
            }

            return controle;
        }

    }

    public class ControleExecucao
    {
        public DateTime Data { get; set; }
        public bool Antiparasitario { get; set; }
        public bool Suplemento { get; set; }
        public bool Vermifugo { get; set; }
        public bool Racao { get; set; }
        public bool Welcome { get; set; }
        public bool Vacina { get; set; }
        public bool Milteforan { get; set; }
        public string Usuario { get; set; }
    }
}
