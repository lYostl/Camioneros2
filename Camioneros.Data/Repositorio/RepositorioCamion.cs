﻿using Camioneros.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camioneros.Data.Repositorio
{
    public class RepositorioCamion : InterfaceCamion
    {
        private readonly MySQLConfiguration _connectionString;

        public RepositorioCamion(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public Task<IEnumerable<Camion>> GetAllCamion()
        {
            var db = dbConnection();
            var sql = @"SELECT id,id_Camionero,Marca,Patente,Tipo,Peso,Peso_Carga,GPS_Cortacorriente FROM camion";

            return db.QueryAsync<Camion>(sql, new { });
        }

        public async Task<Camion> GetCamion(int ID)
        {
            var db = dbConnection();
            var sql = @"SELECT ID,id_Camionero,Marca,Patente,Tipo,Peso,Peso_Carga,
                      GPS_Cortacorriente 
                      FROM camion
                      WHERE ID = @Id";

            return await db.QueryFirstOrDefaultAsync<Camion>(sql, new { Id = ID });
        }

        public async Task<bool> InsertCamion(Camion camion)
        {
            var db = dbConnection();
            var sql = "INSERT INTO camion(ID,id_Camionero,Marca,Patente,Tipo,Peso,Peso_Carga,GPS_Cortacorriente) VALUES (@ID,@id_Camionero,@Marca,@Patente,@Tipo,@Peso,@Peso_Carga,@GPS_Cortacorriente)";

            var result = await db.ExecuteAsync(sql, new
            {
                camion.ID,
                camion.id_Camionero,
                camion.Marca,
                camion.Patente,
                camion.Tipo,
                camion.Peso,
                camion.Peso_Carga,
                camion.GPS_Cortacorriente
            });
            return result > 0;
        }

        public async Task<bool> UpdateCamion(Camion camion)
        {
            var db = dbConnection();
            var sql = @"UPDATE camion SET Marca=@Marca,Patente=@Patente,Tipo=@Tipo,
                      Peso=@Peso,Peso_Carga=@Peso_Carga,
                      GPS_Cortacorriente=@GPS_Corriente
                      WHERE ID = @Id"
                      ;


            var result = await db.ExecuteAsync(sql, new
            {
                camion.ID,
                camion.id_Camionero,
                camion.Marca,
                camion.Patente,
                camion.Tipo,
                camion.Peso,
                camion.Peso_Carga,
                camion.GPS_Cortacorriente
            });
            return result > 0;
        }

        public async Task<bool> DeleteCamion(Camion camion)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM camion WHERE ID = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = camion.ID });

            return result > 0;
        }

    }
}
