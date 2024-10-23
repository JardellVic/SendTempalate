using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CRM.conexao
{
    internal class conexaoMouraRetorno
    {
        private readonly string connectionString = "Server=cloudecia.jnmoura.com.br,1504;Database=CAESECIAMG_10221;User Id=CAESECIAMG_10221_POWERBI;Password=KI8msYRpRsRJifEw2ouw;TrustServerCertificate=True;";

        public DataTable FetchData(List<string> codigos, DateTime startDate, DateTime endDate)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = $@"
                        SELECT 
                            p.nome,
                            vi.Produto,
                            pr.Nome AS Nome_Produto,
                            CONVERT(varchar, v.data, 103) AS [Data da Venda],
                            u.nome AS Vendedor
                        FROM 
                            pessoa p
                        INNER JOIN 
                            cliente c ON p.Codigo = c.Pessoa
                        INNER JOIN 
                            venda v ON v.cliente = c.Pessoa
                        INNER JOIN 
                            venda_item vi ON vi.venda = v.Codigo
                        INNER JOIN 
                            produto pr ON vi.Produto = pr.codigo
                        INNER JOIN 
                            empresa e ON e.codigo = v.empresa
                        INNER JOIN 
                            usuario u ON v.vendedor = u.codigo
                        WHERE 
                            v.data BETWEEN @startDate AND @endDate 
                            AND ISNULL(V.Cancelada, 'N') = 'N'
                            AND v.vendedor IN ('{string.Join("','", codigos)}')
                        ORDER BY 
                            v.data ASC;
                    ";


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd 00:00:00"));
                        cmd.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd 23:59:59"));

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar os dados: " + ex.Message);
            }

            return dataTable;
        }
    }
}
