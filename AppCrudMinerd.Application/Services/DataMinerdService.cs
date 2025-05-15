using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCrudMinerd.Application.Dtos;
using AppCrudMinerd.Application.Interfaces.Repositories;
using AppCrudMinerd.Application.Interfaces.Services;
using AppCrudMinerd.Persistence.Entities;

namespace AppCrudMinerd.Application.Services
{
    public class DataMinerdService : IDataMinerdService
    {
        private readonly IDataMinerdRepository _repo;

        public DataMinerdService(IDataMinerdRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<DataMinerdDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return entities.Select(e => new DataMinerdDto
            {
                Site = e.Site,
                Circuito = e.Circuito,
                Nombre_Escuela = e.Nombre_Escuela,
                WAN_IP = e.WAN_IP,
                Latitud = e.Latitud,
                Longitud = e.Longitud,
                Long_Name = e.Long_Name,
                Nombre_Contacto = e.Nombre_Contacto,
                Telefono_Contacto = e.Telefono_Contacto,
                Regional = e.Regional,
                Distrito = e.Distrito,
                Codigo_Planta_Fisica = e.Codigo_Planta_Fisica,
                Hostname = e.Hostname,
                DDNS = e.DDNS,
                IP_Gestion_FMG = e.IP_Gestion_FMG,
                IP_Gestion_SW = e.IP_Gestion_SW,
                SSHStatus = e.SSHStatus,
                LastSSHTest = e.LastSSHTest,
                PingStatus = e.PingStatus,
                LastPingTest = e.LastPingTest,
                Fortigate = e.Fortigate,
                Fortigate_FW = e.Fortigate_FW,
                Fortigate_HTTPS = e.Fortigate_HTTPS,
                SiteType = e.SiteType
            });
        }

        public async Task<DataMinerdDto?> GetByIdAsync(string site)
        {
            var e = await _repo.GetByIdAsync(site);
            if (e == null) return null;

            return new DataMinerdDto
            {
                Site = e.Site,
                Circuito = e.Circuito,
                Nombre_Escuela = e.Nombre_Escuela,
                WAN_IP = e.WAN_IP,
                Latitud = e.Latitud,
                Longitud = e.Longitud,
                Long_Name = e.Long_Name,
                Nombre_Contacto = e.Nombre_Contacto,
                Telefono_Contacto = e.Telefono_Contacto,
                Regional = e.Regional,
                Distrito = e.Distrito,
                Codigo_Planta_Fisica = e.Codigo_Planta_Fisica,
                Hostname = e.Hostname,
                DDNS = e.DDNS,
                IP_Gestion_FMG = e.IP_Gestion_FMG,
                IP_Gestion_SW = e.IP_Gestion_SW,
                SSHStatus = e.SSHStatus,
                LastSSHTest = e.LastSSHTest,
                PingStatus = e.PingStatus,
                LastPingTest = e.LastPingTest,
                Fortigate = e.Fortigate,
                Fortigate_FW = e.Fortigate_FW,
                Fortigate_HTTPS = e.Fortigate_HTTPS,
                SiteType = e.SiteType
            };
        }

        public async Task CreateAsync(CreateDataMinerdDto dto)
        {
            var entity = new DataMinerd
            {
                Site = dto.Site,                // si es PK asignable
                Circuito = dto.Circuito,
                Nombre_Escuela = dto.Nombre_Escuela,
                WAN_IP = dto.WAN_IP,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                Long_Name = dto.Long_Name,
                Nombre_Contacto = dto.Nombre_Contacto,
                Telefono_Contacto = dto.Telefono_Contacto,
                Regional = dto.Regional,
                Distrito = dto.Distrito,
                Codigo_Planta_Fisica = dto.Codigo_Planta_Fisica,
                Hostname = dto.Hostname,
                DDNS = dto.DDNS,
                IP_Gestion_FMG = dto.IP_Gestion_FMG,
                IP_Gestion_SW = dto.IP_Gestion_SW,
                SSHStatus = dto.SSHStatus,
                LastSSHTest = dto.LastSSHTest,
                PingStatus = dto.PingStatus,
                LastPingTest = dto.LastPingTest,
                Fortigate = dto.Fortigate,
                Fortigate_FW = dto.Fortigate_FW,
                Fortigate_HTTPS = dto.Fortigate_HTTPS,
                SiteType = dto.SiteType
            };

            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(string site, UpdateDataMinerdDto dto)
        {
            var e = await _repo.GetByIdAsync(site);
            if (e == null) return;

            // Actualiza solo los campos presentes en el DTO
            e.Circuito = dto.Circuito;
            e.Nombre_Escuela = dto.Nombre_Escuela;
            e.WAN_IP = dto.WAN_IP;
            e.Latitud = dto.Latitud;
            e.Longitud = dto.Longitud;
            e.Long_Name = dto.Long_Name;
            e.Nombre_Contacto = dto.Nombre_Contacto;
            e.Telefono_Contacto = dto.Telefono_Contacto;
            e.Regional = dto.Regional;
            e.Distrito = dto.Distrito;
            e.Codigo_Planta_Fisica = dto.Codigo_Planta_Fisica;
            e.Hostname = dto.Hostname;
            e.DDNS = dto.DDNS;
            e.IP_Gestion_FMG = dto.IP_Gestion_FMG;
            e.IP_Gestion_SW = dto.IP_Gestion_SW;
            e.SiteType = dto.SiteType;

            await _repo.UpdateAsync(e);
        }

        public async Task DeleteAsync(string site)
        {
            await _repo.DeleteAsync(site);
        }
    }
}
