
using Microsoft.EntityFrameworkCore;
using WebAppGM.Models;
using WebappGM_API.Models;
using WebappGM_API.Models.Mantenimiento;
using WebappGM_API.Models.OrdenesTrabajo;
using WebappGM_API.Models.OrdenesTrabajoB;

namespace WepAppGM.Models
{
    public class DbGmContext: DbContext
    {
        public DbGmContext(DbContextOptions<DbGmContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Filtro por tipos*/
            modelBuilder.Entity<gm_barco>().HasQueryFilter(x => x.estado == 1);
            modelBuilder.Entity<gm_barco>().HasIndex(b => b.nombre).IsUnique();

            modelBuilder.Entity<gm_maquinaria>().HasQueryFilter(x => x.estado == 1);
            modelBuilder.Entity<gm_maquinaria>().HasIndex(b => b.modelo).IsUnique();

            modelBuilder.Entity<gm_magnitud>().HasQueryFilter(x => x.estado == 1);
            modelBuilder.Entity<gm_magnitud>().HasIndex(b => b.nombre).IsUnique();
            modelBuilder.Entity<gm_unidad>().HasQueryFilter(x => x.estado == 1);

            modelBuilder.Entity<gm_item>().HasQueryFilter(x => x.estado == 1);
            modelBuilder.Entity<gm_item>().HasIndex(b => b.nombre).IsUnique();

            modelBuilder.Entity<gm_itemCategory>().HasIndex(b => b.nombre).IsUnique();

            modelBuilder.Entity<gm_identidadM>().HasQueryFilter(x => x.estado == 1);

            modelBuilder.Entity<gm_planMantenimiento>().HasQueryFilter(x => x.estado == 1);
            modelBuilder.Entity<gm_planMantenimiento>().HasIndex(b => b.nombre).IsUnique();

            modelBuilder.Entity<gm_medicionM>().HasQueryFilter(x => x.estado == 1);

            // Seed
            modelBuilder.Entity<gm_maquinaria>().HasData(
                //real
                new gm_maquinaria { idMaquina = 1, tipoMaquinaria= "Motor", modelo = "7FDM-16D3", marca = "GENERAL ELECTRIC", estado= 1, planMantenimientoId= 1 },
                new gm_maquinaria { idMaquina = 2, tipoMaquinaria = "Separador", modelo = "103B-24", marca = "ALFA LAVAL", estado = 1, planMantenimientoId = null },
                new gm_maquinaria { idMaquina = 3, tipoMaquinaria = "Motor", modelo = "3512", marca = "Caterpillar", estado = 1, planMantenimientoId = 2 },
                new gm_maquinaria { idMaquina = 4, tipoMaquinaria = "Motor", modelo = "3512B", marca = "Caterpillar", estado = 1, planMantenimientoId = 3 },
                new gm_maquinaria { idMaquina = 5, tipoMaquinaria = "Motor", modelo = "c18", marca = "Caterpillar", estado = 1, planMantenimientoId = 4 },
                new gm_maquinaria { idMaquina = 6, tipoMaquinaria = "Motor", modelo = "3406", marca = "Caterpillar", estado = 1, planMantenimientoId = 5},
                new gm_maquinaria { idMaquina = 7, tipoMaquinaria = "Motor", modelo = "3408", marca = "Caterpillar", estado = 1, planMantenimientoId = null},
                new gm_maquinaria { idMaquina = 8, tipoMaquinaria = "Motor", modelo = "TD100A", marca = "Volvo Penta", estado = 1, planMantenimientoId = null},
                new gm_maquinaria { idMaquina = 9, tipoMaquinaria = "Motor", modelo = "4BT3.9-D", marca = "Cummins", estado = 1, planMantenimientoId = null},
                new gm_maquinaria { idMaquina = 10, tipoMaquinaria = "Motor", modelo = "3306", marca = "Caterpillar", estado = 1, planMantenimientoId = null },
                new gm_maquinaria { idMaquina = 11, tipoMaquinaria = "Motor", modelo = "c4", marca = "Caterpillar", estado = 1, planMantenimientoId = null },
                new gm_maquinaria { idMaquina = 12, tipoMaquinaria = "Motor", modelo = "3412", marca = "Caterpillar", estado = 1, planMantenimientoId = null },
                new gm_maquinaria { idMaquina = 13, tipoMaquinaria = "Motor", modelo = "3508B", marca = "Caterpillar", estado = 1, planMantenimientoId = 3 }
                );

            //real
            modelBuilder.Entity<gm_barco>().HasData(
                new gm_barco { idBarco = 1, nombre = "B/P CAP BERNY B", armador = "DANIEL ROBERTO BUEHS BOWEN", constructorB = "LUZURIAGA", lugarConstruccion = "ESPAÑA", anioConstruccion = "1980-06", lugarReConstruccion=null, anioReConstruccion=null, numMatricula= "P-04-00584", materialCasco ="ACERO NAVAL", eslora= 65.1M , manga=11.6M, puntal=5.7M, calado = 5.5M, tonelajeBruto =1514, tonelajeNeto=454, desMaximaCarga=2363, capacidadBodega=1269, tipoBodega= "INSULADA", metodoPesca= "RED DE CERCO", nombreI= "/assets/img/img_CAP_BERNY_B.jpg",  estado = 1 }, 
                new gm_barco { idBarco = 2, nombre = "B/P BERNARDITA B", armador = "B&B TUNE SUPPLIERS S.A.", constructorB = "FERGUSON INDUSTRIES LTDA", lugarConstruccion = "CANADA", anioConstruccion = "1970-12",lugarReConstruccion="PUERTO DE MANTA Y ASTILLERO MARIDUEÑA",anioReConstruccion="2017-12", numMatricula = "P-04-00980", materialCasco = "ACERO NAVAL", eslora = 34.98m, manga = 9.59M, puntal = 3.99M,calado=2.98M, tonelajeBruto = 311.08M, tonelajeNeto = 93, desMaximaCarga = 0, capacidadBodega = 352.04M, tipoBodega = "INSULADA", metodoPesca = "RED DE CERCO", nombreI = "/assets/img/img_BERNARDITA_B.jpg", estado = 1 },
                new gm_barco { idBarco = 3, nombre = "B/P EL CONDE", armador = "B&B TUNE SUPPLIERS S.A.", constructorB = "FERGUSON INDUSTRIES LTDA", lugarConstruccion = "CANADA", anioConstruccion = "1972-12", lugarReConstruccion = null, anioReConstruccion = null, numMatricula = "P-04-00807", materialCasco = "ACERO NAVAL", eslora = 33.33m, manga = 8.55M, puntal = 6.44M, calado = 2.50M, tonelajeBruto = 245.64M, tonelajeNeto = 0, desMaximaCarga = 0, capacidadBodega = 0, tipoBodega = "INSULADA", metodoPesca = "RED DE CERCO", nombreI = "/assets/img/img_El_conde.jpg", estado = 1 },
                new gm_barco { idBarco = 4, nombre = "B/P SOUTHERN QUEEN", armador = "MANACRIPEX CÍA. LTDA.", constructorB = "TACOMA BOAT WORKS", lugarConstruccion = "TACOMA", anioConstruccion = "1947-02", lugarReConstruccion = null, anioReConstruccion = null, numMatricula = "P-04-00408", materialCasco = "ACERO NAVAL", eslora = 36.8M, manga = 7.8M, puntal = 6.25M, calado = 3.1M, tonelajeBruto = 302.18M, tonelajeNeto = 0, desMaximaCarga = 0, capacidadBodega = 0, tipoBodega = "INSULADA", metodoPesca = "RED DE CERCO", nombreI = "/assets/img/img_SOUTHERN_QUEEN.jpg", estado = 1 },
                new gm_barco { idBarco = 5, nombre = "B/P CAP TINO B", armador = "B&B TUNE SUPPLIERS S.A.", constructorB = "FERGUSON INDUSTRIES LTDA", lugarConstruccion = "CANADA", anioConstruccion = "1970-01", lugarReConstruccion = null, anioReConstruccion = null, numMatricula = "P-04-00820", materialCasco = "ACERO NAVAL", eslora = 34.98m, manga = 9.14M, puntal = 3.99M, calado = 3.8M, tonelajeBruto = 344.69M, tonelajeNeto = 0, desMaximaCarga = 0, capacidadBodega = 0, tipoBodega = "INSULADA", metodoPesca = "RED DE CERCO", nombreI = "/assets/img/img_CAP_TINO_B.jpg", estado = 1 },
                new gm_barco { idBarco = 6, nombre = "B/P CAP DANNY B", armador = "B&B TUNE SUPPLIERS S.A.", constructorB = "FERGUSON INDUSTRIES LTDA", lugarConstruccion = "CANADA", anioConstruccion = "1970-01", lugarReConstruccion = null, anioReConstruccion = null, numMatricula = "P-04-00894", materialCasco = "ACERO NAVAL", eslora = 34.98m, manga = 9.14M, puntal = 6.30M, calado = 2.98M, tonelajeBruto = 343.45M, tonelajeNeto = 0, desMaximaCarga = 0, capacidadBodega = 0, tipoBodega = "INSULADA", metodoPesca = "RED DE CERCO", nombreI = "/assets/img/img_CAP_DANNY_B.jpg", estado = 1 },
                new gm_barco { idBarco = 7, nombre = "B/P MARINERO", armador = "FRESH FISH DEL ECUADOR CÍA. LTDA.", constructorB = "", lugarConstruccion = "MANTA", anioConstruccion = "2014-07", lugarReConstruccion = null, anioReConstruccion = null, numMatricula = "P-04-00952", materialCasco = "ACERO NAVAL", eslora = 17.75m, manga = 6.10M, puntal = 3.45M, calado = 2.43M, tonelajeBruto = 125.59M, tonelajeNeto = 0, desMaximaCarga = 0, capacidadBodega = 0, tipoBodega = "INSULADA", metodoPesca = "RED DE CERCO", nombreI = "/assets/img/img_MARINERO.jpg", estado = 1 }
                );

            //real
            modelBuilder.Entity<gm_identidadM>().HasData(
                new gm_identidadM { idIdentidadM = 1, nombre = "Motor", estado = 1 },
                new gm_identidadM { idIdentidadM = 2, nombre = "Reductora", estado = 1 },
                new gm_identidadM { idIdentidadM = 3, nombre = "Compresor", estado = 1 },
                new gm_identidadM { idIdentidadM = 4, nombre = "Purificador", estado = 1 },
                new gm_identidadM { idIdentidadM = 5, nombre = "Separador", estado = 1 },
                new gm_identidadM { idIdentidadM = 6, nombre = "Generador", estado = 1 }
                );

            //real
            modelBuilder.Entity<gm_magnitud>().HasData(
                new gm_magnitud { idMagnitud = 1, nombre = "Potencia", estado = 1 },
                new gm_magnitud { idMagnitud = 2, nombre = "Longtud", estado = 1 },
                new gm_magnitud { idMagnitud = 3, nombre = "Masa", estado = 1 },
                new gm_magnitud { idMagnitud = 4, nombre = "Frecuencia", estado = 1 },
                new gm_magnitud { idMagnitud = 5, nombre = "Energia", estado = 1 },
                new gm_magnitud { idMagnitud = 6, nombre = "Matemática", estado = 1 },
                new gm_magnitud { idMagnitud = 7, nombre = "Presión ", estado = 1 },
                new gm_magnitud { idMagnitud = 8, nombre = "Voltaje ", estado = 1 },
                new gm_magnitud { idMagnitud = 9, nombre = "Intensidad ", estado = 1 },
                new gm_magnitud { idMagnitud = 10, nombre = "Texto", estado = 1 }
                );

            modelBuilder.Entity<gm_unidad>().HasData(
                new gm_unidad { idUnidad = 1, nombre = "julios", simbolo="j", estado = 1, magnitudId=5 },
                new gm_unidad { idUnidad = 2, nombre = "Caballos vapor", simbolo = "CV/HP", estado = 1, magnitudId = 1 },
                new gm_unidad { idUnidad = 3, nombre = "Kilovatio", simbolo = "kW", estado = 1, magnitudId = 1 },
                new gm_unidad { idUnidad = 4, nombre = "Centimetro", simbolo = "cm", estado = 1, magnitudId = 2 },
                new gm_unidad { idUnidad = 5, nombre = "Metro", simbolo = "m", estado = 1, magnitudId = 2 },
                new gm_unidad { idUnidad = 6, nombre = "Kilogramo", simbolo = "Kg", estado = 1, magnitudId = 3 },
                new gm_unidad { idUnidad = 7, nombre = "Gramo", simbolo = "g", estado = 1, magnitudId = 3 },
                new gm_unidad { idUnidad = 8, nombre = "Revoluciones por min", simbolo = "rpm", estado = 1, magnitudId = 4 },
                new gm_unidad { idUnidad = 9, nombre = "Unidad", simbolo = "Und", estado = 1, magnitudId = 6 },
                new gm_unidad { idUnidad = 10, nombre = "Docena", simbolo = "12U", estado = 1, magnitudId = 6 },
                new gm_unidad { idUnidad = 11, nombre = "Hercios", simbolo = "Hz", estado = 1, magnitudId = 4 },
                new gm_unidad { idUnidad = 12, nombre = "Libra x pulgada cuadrada", simbolo = "Psi", estado = 1, magnitudId = 7 },
                new gm_unidad { idUnidad = 13, nombre = "Voltio", simbolo = "v", estado = 1, magnitudId = 8 },
                new gm_unidad { idUnidad = 14, nombre = "Amperio", simbolo = "A", estado = 1, magnitudId = 9},
                new gm_unidad { idUnidad = 15, nombre = "Tipo", simbolo = "tipo", estado = 1, magnitudId = 10 }
                );

            modelBuilder.Entity<gm_itemCategory>().HasData(
                new gm_itemCategory { idItemCategory = 1, nombre = "Nominal", estado = 1 },
                new gm_itemCategory { idItemCategory = 2, nombre = "Ceiling", estado = 1 },
                new gm_itemCategory { idItemCategory = 3, nombre = "Floor", estado = 1 },
                new gm_itemCategory { idItemCategory = 4, nombre = "Valor Numérico", estado = 1 },
                new gm_itemCategory { idItemCategory = 5, nombre = "Valor Texto", estado = 1 }
                );

            modelBuilder.Entity<gm_item>().HasData(
                new gm_item { idItem = 1, nombre = "Corr Full Load Power", estado = 1, magnitudId = 1},
                new gm_item { idItem = 2, nombre = "Full Load Speed", estado = 1, magnitudId = 4 },
                new gm_item { idItem = 3, nombre = "High Idle Speed", estado = 1, magnitudId = 4 },
                new gm_item { idItem = 4, nombre = "Potencia", estado = 1, magnitudId = 1 },
                new gm_item { idItem = 5, nombre = "Low Idle Speed", estado = 1, magnitudId = 4 },
                new gm_item { idItem = 6, nombre = "No Cilindros", estado = 1, magnitudId = 6 },
                new gm_item { idItem = 7, nombre = "Voltaje", estado = 1, magnitudId = 4 },
                new gm_item { idItem = 8, nombre = "Intensidad", estado = 1, magnitudId = 9 },
                new gm_item { idItem = 9, nombre = "No Fase", estado = 1, magnitudId = 6 },
                new gm_item { idItem = 10, nombre = "Tipo de Combustible", estado = 1, magnitudId = 10 },
                new gm_item { idItem = 11, nombre = "Marca de Aceite", estado = 1, magnitudId = 10 }
                );
            
            modelBuilder.Entity<gm_item_itemCategory>().HasData(
                new gm_item_itemCategory { idItem_itemCategory = 1, itemId = 4, itemCategoryId = 4, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 2, itemId = 1, itemCategoryId = 1, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 3, itemId = 1, itemCategoryId = 2, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 4, itemId = 1, itemCategoryId = 3, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 5, itemId = 2, itemCategoryId = 1, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 6, itemId = 2, itemCategoryId = 2, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 7, itemId = 2, itemCategoryId = 3, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 8, itemId = 3, itemCategoryId = 1, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 9, itemId = 3, itemCategoryId = 2, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 10, itemId = 3, itemCategoryId = 3, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 11, itemId = 5, itemCategoryId = 1, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 12, itemId = 5, itemCategoryId = 2, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 13, itemId = 5, itemCategoryId = 3, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 14, itemId = 6, itemCategoryId = 4, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 15, itemId = 7, itemCategoryId = 4, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 16, itemId = 8, itemCategoryId = 4, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 17, itemId = 9, itemCategoryId = 4, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 18, itemId = 10, itemCategoryId = 5, estado = 1 },
                new gm_item_itemCategory { idItem_itemCategory = 19, itemId = 11, itemCategoryId = 5, estado = 1 }
                );

            modelBuilder.Entity<gm_detalleFichaM>().HasData(
                
                new gm_detalleFichaM { idDetalleFichaM = 1, maquinariaId = 3, itemId = 6, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 2, maquinariaId = 3, itemId = 10, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 3, maquinariaId = 5, itemId = 6, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 4, maquinariaId = 5, itemId = 10, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 5, maquinariaId = 8, itemId = 6, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 6, maquinariaId = 8, itemId = 10, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 7, maquinariaId = 7, itemId = 6, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 8, maquinariaId = 7, itemId = 10, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 9, maquinariaId = 6, itemId = 6, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 10, maquinariaId = 6, itemId = 10, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 11, maquinariaId = 4, itemId = 6, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 12, maquinariaId = 4, itemId = 10, estado = 1 },     
                new gm_detalleFichaM { idDetalleFichaM = 13, maquinariaId = 9, itemId = 6, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 14, maquinariaId = 9, itemId = 10, estado = 1 },    
                new gm_detalleFichaM { idDetalleFichaM = 15, maquinariaId = 1, itemId = 6, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 16, maquinariaId = 1, itemId = 10, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 17, maquinariaId = 10, itemId = 6, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 18, maquinariaId = 10, itemId = 10, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 19, maquinariaId = 11, itemId = 6, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 20, maquinariaId = 11, itemId = 10, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 21, maquinariaId = 12, itemId = 6, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 22, maquinariaId = 12, itemId = 10, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 23, maquinariaId = 13, itemId = 6, estado = 1 },
                new gm_detalleFichaM { idDetalleFichaM = 24, maquinariaId = 13, itemId = 10, estado = 1 }
           );

           modelBuilder.Entity<gm_item_identidad>().HasData(
                new gm_item_identidad { idItem_identidad = 1, itemId = 4, identidadMId = 1, opcional = true, estado= 1 },
                new gm_item_identidad { idItem_identidad = 2, itemId = 1, identidadMId = 1, opcional = true, estado = 1 },
                new gm_item_identidad { idItem_identidad = 3, itemId = 2, identidadMId = 1, opcional = true, estado = 1 },
                new gm_item_identidad { idItem_identidad = 4, itemId = 3, identidadMId = 1, opcional = true, estado = 1 },
                new gm_item_identidad { idItem_identidad = 5, itemId = 5, identidadMId = 1, opcional = true, estado = 1 },
                new gm_item_identidad { idItem_identidad = 6, itemId = 6, identidadMId = 1, opcional = false, estado = 1 },
                new gm_item_identidad { idItem_identidad = 7, itemId = 7, identidadMId = 5, opcional = false, estado = 1 },
                new gm_item_identidad { idItem_identidad = 8, itemId = 9, identidadMId = 5, opcional = false, estado = 1 },
                new gm_item_identidad { idItem_identidad = 9, itemId = 8, identidadMId = 6, opcional = true, estado = 1 },
                new gm_item_identidad { idItem_identidad = 10, itemId = 4, identidadMId = 6, opcional = false, estado = 1 },
                new gm_item_identidad { idItem_identidad = 11, itemId = 4, identidadMId = 5, opcional = false, estado = 1 },
                new gm_item_identidad { idItem_identidad = 12, itemId = 4, identidadMId = 3, opcional = false, estado = 1 },
                new gm_item_identidad { idItem_identidad = 13, itemId = 6, identidadMId = 3, opcional = true, estado = 1 },
                new gm_item_identidad { idItem_identidad = 14, itemId = 10, identidadMId = 1, opcional = false, estado = 1 },
                new gm_item_identidad { idItem_identidad = 15, itemId = 11, identidadMId = 1, opcional = true, estado = 1 }
                );

            modelBuilder.Entity<gm_detalleCollection>().HasData(
                new gm_detalleCollection { idDetalleCollection = 1, detalleFichaMId = 1, itemCategoryId = 4, valor = "6", unidadId = 9 },
                new gm_detalleCollection { idDetalleCollection = 2, detalleFichaMId = 2, itemCategoryId = 5, valor = "Diésel", unidadId = 15 },
                new gm_detalleCollection { idDetalleCollection = 3, detalleFichaMId = 3, itemCategoryId = 4, valor = "6", unidadId = 9 },
                new gm_detalleCollection { idDetalleCollection = 4, detalleFichaMId = 4, itemCategoryId = 5, valor = "Diésel", unidadId = 15 },
                new gm_detalleCollection { idDetalleCollection = 5, detalleFichaMId = 5, itemCategoryId = 4, valor = "6", unidadId = 9 },
                new gm_detalleCollection { idDetalleCollection = 6, detalleFichaMId = 6, itemCategoryId = 5, valor = "Diésel", unidadId = 15 },
                new gm_detalleCollection { idDetalleCollection = 7, detalleFichaMId = 7, itemCategoryId = 4, valor = "8", unidadId = 9 },
                new gm_detalleCollection { idDetalleCollection = 8, detalleFichaMId = 8, itemCategoryId = 5, valor = "Diésel", unidadId = 15 },
                new gm_detalleCollection { idDetalleCollection = 9, detalleFichaMId = 9, itemCategoryId = 4, valor = "6", unidadId = 9 },
                new gm_detalleCollection { idDetalleCollection = 10, detalleFichaMId = 10, itemCategoryId = 5, valor = "Diésel", unidadId = 15 },
                new gm_detalleCollection { idDetalleCollection = 11, detalleFichaMId = 11, itemCategoryId = 4, valor = "12", unidadId = 9 },
                new gm_detalleCollection { idDetalleCollection = 12, detalleFichaMId = 12, itemCategoryId = 5, valor = "Diésel", unidadId = 15 },
                new gm_detalleCollection { idDetalleCollection = 13, detalleFichaMId = 13, itemCategoryId = 4, valor = "4", unidadId = 9 },
                new gm_detalleCollection { idDetalleCollection = 14, detalleFichaMId = 14, itemCategoryId = 5, valor = "Diésel", unidadId = 15 },
                new gm_detalleCollection { idDetalleCollection = 15, detalleFichaMId = 15, itemCategoryId = 4, valor = "12", unidadId = 9 },
                new gm_detalleCollection { idDetalleCollection = 16, detalleFichaMId = 16, itemCategoryId = 5, valor = "Diésel", unidadId = 15 },
                new gm_detalleCollection { idDetalleCollection = 17, detalleFichaMId = 17, itemCategoryId = 4, valor = "6", unidadId = 9 },
                new gm_detalleCollection { idDetalleCollection = 18, detalleFichaMId = 18, itemCategoryId = 5, valor = "Diésel", unidadId = 15 },
                new gm_detalleCollection { idDetalleCollection = 19, detalleFichaMId = 19, itemCategoryId = 4, valor = "4", unidadId = 9 },
                new gm_detalleCollection { idDetalleCollection = 20, detalleFichaMId = 20, itemCategoryId = 5, valor = "Diésel", unidadId = 15 },
                new gm_detalleCollection { idDetalleCollection = 21, detalleFichaMId = 21, itemCategoryId = 4, valor = "12", unidadId = 9 },
                new gm_detalleCollection { idDetalleCollection = 22, detalleFichaMId = 22, itemCategoryId = 5, valor = "Diésel", unidadId = 15 },
                new gm_detalleCollection { idDetalleCollection = 23, detalleFichaMId = 23, itemCategoryId = 4, valor = "8", unidadId = 9 },
                new gm_detalleCollection { idDetalleCollection = 24, detalleFichaMId = 24, itemCategoryId = 5, valor = "Diésel", unidadId = 15 }
                );

            modelBuilder.Entity<gm_barco_maquinaria>().HasData(
                //real
                new gm_barco_maquinaria { idBarcoMaquinaria = 1, nombre = "M/P", barcoId = 1, maquinariaId = 1, serie = "308749", horasServicio = 0, fechaIncorporacionB = "2017-04-21", checkMaquinaria = true, estado = 1, potencia= 111, unidadId=1, nombreI = "/assets/img/imgDefecto.png" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 2, nombre = "2", barcoId = 1, maquinariaId = 3, serie = "N/D", horasServicio = 27, fechaIncorporacionB = "2018-08-09", checkMaquinaria = true, estado = 0, nombreI = "/assets/img/imgDefecto.png" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 3, nombre = "3", barcoId = 1, maquinariaId = 2, serie = "4179215", horasServicio = 0,  fechaIncorporacionB = "2017-04-21", checkMaquinaria = false, estado = 0, nombreI = "/assets/img/imgDefecto.png" },          
                new gm_barco_maquinaria { idBarcoMaquinaria = 4, nombre = "M/P", barcoId = 2, maquinariaId = 3, serie = "S2K00367", horasServicio = 6720,  fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado=1, potencia = 969.5M, unidadId = 3, nombreI = "/assets/img/bBernardita_Mmp3512.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 5, nombre = "Generador de Estribor", barcoId = 2, maquinariaId = 5, serie = "8HG03304",horasServicio = 4683, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 499, unidadId = 2, nombreI = "/assets/img/imgDefecto.png" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 6, nombre = "Generador de Babor", barcoId = 2, maquinariaId = 5, serie = "8HE03307", horasServicio = 6331, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 499, unidadId = 2, nombreI = "/assets/img/bBernardita_MauxBc18.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 7, nombre = "VolvoPenta", barcoId = 2, maquinariaId = 8, serie = "97911", horasServicio = 6349, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 60, unidadId = 3, nombreI = "/assets/img/bBernardita_MvolvoTD100A.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 8, nombre = "Motor Hidráulico", barcoId = 2, maquinariaId = 7, serie = "99U06119", horasServicio = 1268, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 402, unidadId = 2, nombreI = "/assets/img/imgDefecto.png" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 9, nombre = "Panga", barcoId = 2, maquinariaId = 6, serie = "EZJ17718", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 380, unidadId = 2, nombreI = "/assets/img/imgDefecto.png" },           
                new gm_barco_maquinaria { idBarcoMaquinaria = 10, nombre = "M/P", barcoId = 5, maquinariaId = 4, serie = "S2K00366", horasServicio = 22464, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 0, unidadId = 2, nombreI = "/assets/img/imgDefecto.png" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 11, nombre = "Generador de Estribor", barcoId = 5, maquinariaId = 6, serie = "40600986", horasServicio = 8616, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 462, unidadId = 2, nombreI = "/assets/img/bTino_MauxE3406.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 12, nombre = "Generador de Babor", barcoId = 5, maquinariaId = 6, serie = "40601215", horasServicio = 7382, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 462, unidadId = 2, nombreI = "/assets/img/bTino_MauxB3406.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 13, nombre = "Hidráulico", barcoId = 5, maquinariaId = 7, serie = "99U06051", horasServicio = 10144, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 225, unidadId = 2, nombreI = "/assets/img/bTino_Mhidraulico3408.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 14, nombre = "Generador Puerto", barcoId = 5, maquinariaId = 9, serie = "46505859", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 80, unidadId = 2, nombreI = "/assets/img/imgDefecto.png" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 15, nombre = "M/P", barcoId = 6, maquinariaId = 3, serie = "PXX00202", horasServicio = 4891, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 1000, unidadId = 2, nombreI = "/assets/img/bDanny_Mmp3512.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 16, nombre = "Generador de Estribor", barcoId = 6, maquinariaId = 6, serie = "40601614", horasServicio = 38476, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 315, unidadId = 2, nombreI = "/assets/img/bDanny_MauxE3406.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 17, nombre = "Generador de Babor", barcoId = 6, maquinariaId = 7, serie = "78Z04031", horasServicio = 29131, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 415, unidadId = 2, nombreI = "/assets/img/bDanny_MauxB3408.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 18, nombre = "Hidráulico", barcoId = 6, maquinariaId = 5, serie = "WKB00339", horasServicio = 7467, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 450, unidadId = 2, nombreI = "/assets/img/bDanny_MhidraulicoC18.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 19, nombre = "Panga", barcoId = 6, maquinariaId = 6, serie = "00000111", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 315, unidadId = 2, nombreI = "/assets/img/bDanny_Mpanga3406.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 20, nombre = "M/P", barcoId = 3, maquinariaId = 4, serie = "S2K00318", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 1300, unidadId = 2, nombreI = "/assets/img/bConde_Mmp3512B.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 21, nombre = "Generador de Estribor", barcoId = 3, maquinariaId = 6, serie = "PFH00902", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 460, unidadId = 2, nombreI = "/assets/img/bConde_MauxE3406.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 22, nombre = "Generador de Babor", barcoId = 3, maquinariaId = 10, serie = "B8D01018", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 260, unidadId = 2, nombreI = "/assets/img/bConde_MauxB3306.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 23, nombre = "Hidráulico", barcoId = 3, maquinariaId = 5, serie = "T2P01721", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 454, unidadId = 2, nombreI = "/assets/img/bConde_MhidraulicoC18.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 24, nombre = "Generador de Popa", barcoId = 3, maquinariaId = 11, serie = "J1z03621", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 150, unidadId = 2, nombreI = "/assets/img/bConde_MgPopaC4.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 25, nombre = "Generador de Babor", barcoId = 1, maquinariaId = 3, serie = "67Z02024", horasServicio = 81085, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 1200, unidadId = 2, nombreI = "/assets/img/imgDefecto.png" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 26, nombre = "Generador de Estribor", barcoId = 1, maquinariaId = 3, serie = "24Z05438", horasServicio = 32198, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 1200, unidadId = 2, nombreI = "/assets/img/imgDefecto.png" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 27, nombre = "Generador Auxiliar", barcoId = 1, maquinariaId = 12, serie = "38S11748", horasServicio = 38037, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 615, unidadId = 3, nombreI = "/assets/img/imgDefecto.png" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 28, nombre = "Hidráulico", barcoId = 1, maquinariaId = 12, serie = "81Z06477", horasServicio = 5680, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 600, unidadId = 2, nombreI = "/assets/img/imgDefecto.png" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 29, nombre = "M/P", barcoId = 4, maquinariaId = 13, serie = "S2D00183", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 850, unidadId = 2, nombreI = "/assets/img/bSouthernQueen_Mmp3508.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 30, nombre = "Generador de Estribor", barcoId = 4, maquinariaId = 6, serie = "PFH00852", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 460, unidadId = 2, nombreI = "/assets/img/bSouthernQueen_MauxE3406.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 31, nombre = "Generador de Babor", barcoId = 4, maquinariaId = 10, serie = "85Z120903", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 260, unidadId = 2, nombreI = "/assets/img/bSouthernQueen_MauxB3306.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 32, nombre = "Hidráulico", barcoId = 4, maquinariaId = 6, serie = "4TB01381", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 460, unidadId = 2, nombreI = "/assets/img/bSouthernQueen_Mhidraulico3406.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 33, nombre = "Generador de Popa", barcoId = 4, maquinariaId = 9, serie = "46409255", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 80, unidadId = 2, nombreI = "/assets/img/bSouthernQueen_MgPopa4Bt3.9.jpg" },
                new gm_barco_maquinaria { idBarcoMaquinaria = 34, nombre = "Panga", barcoId = 4, maquinariaId = 6, serie = "4TB09546", horasServicio = 0, fechaIncorporacionB = "2014-12-11", checkMaquinaria = true, estado = 1, potencia = 460, unidadId = 2, nombreI = "/assets/img/bSouthernQueen_Mpanga3406.jpg" }
                );


            modelBuilder.Entity<gm_planMantenimiento>().HasData(
                //real
                new gm_planMantenimiento { idPlanMantenimiento = 1, nombre = "M/P 7FDM16D3", descripcion = "Manual de Motor General Electric", fechaCreacion = "2019-10-28", estado = 1 },
                new gm_planMantenimiento { idPlanMantenimiento = 2, nombre = "Auxiliares 3512", descripcion = "Manual de Motores Auxiliares CATERPILLAR", fechaCreacion = "2019-11-06", estado = 1 },
                new gm_planMantenimiento { idPlanMantenimiento = 3, nombre = "Plan: 3508B, 3508C, 3512B, 3512C, 3516B y 3516C Motores marinos ", descripcion = "Manual de Motores CATERPILLAR", fechaCreacion = "2019-11-07", estado = 1 },
                new gm_planMantenimiento { idPlanMantenimiento = 4, nombre = "C18 Motores marinos", descripcion = "Manual de Motores CATERPILLAR modelo c18", fechaCreacion = "2019-12-07", estado = 1 },
                new gm_planMantenimiento { idPlanMantenimiento = 5, nombre = "Plan: 3406c Motores marinos", descripcion = "Manual de Motores CATERPILLAR modelo 3406", fechaCreacion = "2020-01-27", estado = 1 }
                );

            modelBuilder.Entity<gm_tareaM>().HasData(
                new gm_tareaM { idTareaM = 1, nombre = "Sensor de velocidad/sincronización del motor", estado = 1 },
                new gm_tareaM { idTareaM = 2, nombre = "Nivel de electrólito de baterías", estado = 1 },
                new gm_tareaM { idTareaM = 3, nombre = "Muestra de refrigerante (nivel 1)", estado = 1 },
                new gm_tareaM { idTareaM = 4, nombre = "Engine/Motor", estado = 1 },
                new gm_tareaM { idTareaM = 5, nombre = "Recipiente del lubricador del motor de arranque neumático", estado = 1 },
                new gm_tareaM { idTareaM = 6, nombre = "Inyector de combustible", estado = 1 },
                new gm_tareaM { idTareaM = 7, nombre = "Nivel de aceite", estado = 1 },
                new gm_tareaM { idTareaM = 8, nombre = "Nivel del refrigerante", estado = 1 },
                new gm_tareaM { idTareaM = 9, nombre = "Conexiones sueltas", estado = 1 },
                new gm_tareaM { idTareaM = 10, nombre = "Ruidos inusuales", estado = 1 },
                new gm_tareaM { idTareaM = 11, nombre = "Condición de refrigerante", estado = 1 },
                new gm_tareaM { idTareaM = 12, nombre = "Filtros de aceite", estado = 1 },
                new gm_tareaM { idTareaM = 13, nombre = "Manguera de los filtros", estado = 1 },
                new gm_tareaM { idTareaM = 14, nombre = "Filtros de combustible", estado = 1 },
                new gm_tareaM { idTareaM = 15, nombre = "Aceite de la máquina", estado = 1 },
                new gm_tareaM { idTareaM = 16, nombre = "Conexiones del Governor", estado = 1 },
                new gm_tareaM { idTareaM = 17, nombre = "Filtros de aire", estado = 1 },
                new gm_tareaM { idTareaM = 18, nombre = "Cartuchos del filtro coalescente", estado = 1 },
                new gm_tareaM { idTareaM = 19, nombre = "Pestaña de la válvula", estado = 1 },
                new gm_tareaM { idTareaM = 20, nombre = "Temporizador de bomba de combustible", estado = 1 },
                new gm_tareaM { idTareaM = 21, nombre = "Bendix del motor de arranque", estado = 1 },
                new gm_tareaM { idTareaM = 22, nombre = "Boquillas de inyeccion de combustible", estado = 1 },
                new gm_tareaM { idTareaM = 23, nombre = "Aceite de la caja de engranaje del Governor", estado = 1 },
                new gm_tareaM { idTareaM = 24, nombre = "Operación de los elementos de protección del motor", estado = 1 },
                new gm_tareaM { idTareaM = 25, nombre = "Mangueras de combustible", estado = 1 },
                new gm_tareaM { idTareaM = 26, nombre = "Tuercas de la bomba de  combustible", estado = 1 },
                new gm_tareaM { idTareaM = 27, nombre = "Lineas de alta presión", estado = 1 },
                new gm_tareaM { idTareaM = 28, nombre = "Componentes del cigueñal", estado = 1 },
                new gm_tareaM { idTareaM = 29, nombre = "Claros de los endientes de engranajes", estado = 1 },
                new gm_tareaM { idTareaM = 30, nombre = "Claros del túnel del cigueñal", estado = 1 },
                new gm_tareaM { idTareaM = 31, nombre = "Hollín en la entrada de los cilindros", estado = 1 },
                new gm_tareaM { idTareaM = 32, nombre = "Manifold de escape para fugas", estado = 1 },
                new gm_tareaM { idTareaM = 33, nombre = "Nivel de agua dulce de refrigeración", estado = 1 },
                new gm_tareaM { idTareaM = 34, nombre = "Tanque de aire", estado = 1 },
                new gm_tareaM { idTareaM = 35, nombre = "Indicador de servicio del filtro de aire", estado = 1 },
                new gm_tareaM { idTareaM = 36, nombre = "Presión diferencial del filtro de aceite", estado = 1 },
                new gm_tareaM { idTareaM = 37, nombre = "Presión diferencial del filtro de combustible", estado = 1 },
                new gm_tareaM { idTareaM = 38, nombre = "Panel de instrumentos", estado = 1 },
                new gm_tareaM { idTareaM = 39, nombre = "Nivel de aceite del gobernor", estado = 1 },
                new gm_tareaM { idTareaM = 40, nombre = "Motor de arranque de aire", estado = 1 },
                new gm_tareaM { idTareaM = 41, nombre = "Nivel de aceite del motor de arranque", estado = 1 },
                new gm_tareaM { idTareaM = 42, nombre = "Filtro primario del sistema de combustible/Separador de agua", estado = 1 },
                new gm_tareaM { idTareaM = 43, nombre = "Alrededor de la maquina", estado = 1 },
                new gm_tareaM { idTareaM = 44, nombre = "Válvula de drenaje de condensado del posenfriador", estado = 1 },
                new gm_tareaM { idTareaM = 45, nombre = "Colador del agua de mar", estado = 1 },
                new gm_tareaM { idTareaM = 46, nombre = "Varillas de cinc", estado = 1 },
                new gm_tareaM { idTareaM = 47, nombre = "Muestra de refrigerante (nivel 2)", estado = 1 },
                new gm_tareaM { idTareaM = 48, nombre = "Prolongador de refrigerante de larga duración (ELC) para sistemas de enfriamiento", estado = 1 },
                new gm_tareaM { idTareaM = 49, nombre = "Núcleo del posenfriador", estado = 1 },
                new gm_tareaM { idTareaM = 50, nombre = "Refrigerante del sistema de enfriamiento (ELC)", estado = 1 },
                new gm_tareaM { idTareaM = 51, nombre = "Luz de las válvulas del motor", estado = 1 },
                new gm_tareaM { idTareaM = 52, nombre = "Rotaválvulas del motor", estado = 1 },
                new gm_tareaM { idTareaM = 53, nombre = "Bomba de agua auxiliar (rodete de caucho)", estado = 1 },
                new gm_tareaM { idTareaM = 54, nombre = "Correas", estado = 1 },
                new gm_tareaM { idTareaM = 55, nombre = "Aditivo de refrigerante suplementario (SCA) del sistema de enfriamiento", estado = 1 },
                new gm_tareaM { idTareaM = 56, nombre = "Elemento del filtro de aire del motor", estado = 1 },
                new gm_tareaM { idTareaM = 57, nombre = "Respiradero del cárter del motor", estado = 1 },
                new gm_tareaM { idTareaM = 58, nombre = "Muestra de aceite del motor", estado = 1 },
                new gm_tareaM { idTareaM = 59, nombre = "Aceite y filtro del motor", estado = 1 },
                new gm_tareaM { idTareaM = 60, nombre = "Filtro secundario del sistema de combustible", estado = 1 },
                new gm_tareaM { idTareaM = 61, nombre = "Agua y sedimentos del tanque de combustible", estado = 1 },
                new gm_tareaM { idTareaM = 62, nombre = "Mangueras y abrazaderas", estado = 1 },
                new gm_tareaM { idTareaM = 63, nombre = "Intercambiador de calor", estado = 1 },
                new gm_tareaM { idTareaM = 64, nombre = "Turbocompresor", estado = 1 },
                new gm_tareaM { idTareaM = 65, nombre = "Bomba de agua auxiliar (rodete de bronce)", estado = 1 },
                new gm_tareaM { idTareaM = 66, nombre = "Refrigerante del sistema de enfriamiento (DEAC)", estado = 1 },
                new gm_tareaM { idTareaM = 67, nombre = "Termostato del agua del sistema de enfriamiento", estado = 1 },
                new gm_tareaM { idTareaM = 68, nombre = "Amortiguador de vibraciones del cigüeñal", estado = 1 },
                new gm_tareaM { idTareaM = 69, nombre = "Soportes del motor", estado = 1 },
                new gm_tareaM { idTareaM = 70, nombre = "Motor de arranque", estado = 1 },
                new gm_tareaM { idTareaM = 71, nombre = "Alternador", estado = 1 },
                new gm_tareaM { idTareaM = 72, nombre = "Núcleo del enfriador de aceite", estado = 1 },
                new gm_tareaM { idTareaM = 73, nombre = "Bomba de agua ", estado = 1 },
                new gm_tareaM { idTareaM = 74, nombre = "Nivel de aceite del lubricador del motor de arranque neumático", estado = 1 },
                new gm_tareaM { idTareaM = 75, nombre = "Humedad y sedimentos del tanque de aire", estado = 1 },
                new gm_tareaM { idTareaM = 76, nombre = "Depósito de combustible", estado = 1 },
                new gm_tareaM { idTareaM = 77, nombre = "Nivel de aceite de la transmisión ", estado = 1 },
                new gm_tareaM { idTareaM = 78, nombre = "Taza del lubricador del motor de arranque neumático", estado = 1 },
                new gm_tareaM { idTareaM = 79, nombre = "Corte de aire", estado = 1 },
                new gm_tareaM { idTareaM = 80, nombre = "Juego de válvulas del motor", estado = 1 },
                new gm_tareaM { idTareaM = 81, nombre = "Dispositivos de protección del motor", estado = 1 },
                new gm_tareaM { idTareaM = 82, nombre = "Control de la relación de combustible", estado = 1 },
                new gm_tareaM { idTareaM = 83, nombre = "Equipo impulsado", estado = 1 },
                new gm_tareaM { idTareaM = 84, nombre = "Montajes del motor ", estado = 1 },
                new gm_tareaM { idTareaM = 85, nombre = "Motor de arranque neumático", estado = 1 },
                new gm_tareaM { idTareaM = 86, nombre = "Bomba de agua auxiliar", estado = 1 },
                new gm_tareaM { idTareaM = 87, nombre = "Amortiguador de corte de aire", estado = 1 },
                new gm_tareaM { idTareaM = 88, nombre = "Termostato del refrigerante", estado = 1 },
                new gm_tareaM { idTareaM = 89, nombre = "Bomba de prelubricación", estado = 1 },
                new gm_tareaM { idTareaM = 90, nombre = "Seguidores de rodillo del árbol de levas", estado = 1 },

                new gm_tareaM { idTareaM = 91, nombre = "Válvula", estado = 1 },
                new gm_tareaM { idTareaM = 92, nombre = "Cabezotes", estado = 1 },
                new gm_tareaM { idTareaM = 93, nombre = "Empaques", estado = 1 },
                new gm_tareaM { idTareaM = 94, nombre = "Vibraciones del grupo electrógeno", estado = 1 },
                new gm_tareaM { idTareaM = 95, nombre = "Detectores magnéticos", estado = 1 },
                new gm_tareaM { idTareaM = 96, nombre = "Cargador de baterías", estado = 1 },
                new gm_tareaM { idTareaM = 97, nombre = "Cojinetes del mando del ventilador", estado = 1 },
                new gm_tareaM { idTareaM = 98, nombre = "Radiador", estado = 1 },
                new gm_tareaM { idTareaM = 99, nombre = "Mecanismo de control del combustible", estado = 1 }
                );

            modelBuilder.Entity<gm_accionM>().HasData(
                new gm_accionM { idAccionM = 1, nombre = "Revisar", estado = 1 },
                new gm_accionM { idAccionM = 2, nombre = "Limpiar", estado = 1 },
                new gm_accionM { idAccionM = 3, nombre = "Desconectar", estado = 1 },
                new gm_accionM { idAccionM = 4, nombre = "Quitar", estado = 1 },
                new gm_accionM { idAccionM = 5, nombre = "Obtener", estado = 1 },
                new gm_accionM { idAccionM = 6, nombre = "Comprobar", estado = 1 },
                new gm_accionM { idAccionM = 7, nombre = "Reciclar", estado = 1 },
                new gm_accionM { idAccionM = 8, nombre = "Remplazar", estado = 1 },
                new gm_accionM { idAccionM = 9, nombre = "Drenar", estado = 1 },
                new gm_accionM { idAccionM = 10, nombre = "Calibrar", estado = 1 },
                new gm_accionM { idAccionM = 11, nombre = "Cebar", estado = 1 },
                new gm_accionM { idAccionM = 12, nombre = "Soldar", estado = 1 },
                new gm_accionM { idAccionM = 13, nombre = "Controlar", estado = 1 },
                new gm_accionM { idAccionM = 14, nombre = "Verificar", estado = 1 },
                new gm_accionM { idAccionM = 15, nombre = "Inspeccionar", estado = 1 },
                new gm_accionM { idAccionM = 16, nombre = "Cambiar", estado = 1 },
                new gm_accionM { idAccionM = 17, nombre = "Rellenar", estado = 1 },
                new gm_accionM { idAccionM = 18, nombre = "Apretar/Ajustar", estado = 1 },
                new gm_accionM { idAccionM = 19, nombre = "Añadir", estado = 1 },
                new gm_accionM { idAccionM = 20, nombre = "Probar", estado = 1 }
                );

            modelBuilder.Entity<gm_medicionM>().HasData(
                new gm_medicionM { idMedicionM = 1, nombre = "Horas de servicio", simbolo = "h/s", estado = 1 },
                new gm_medicionM { idMedicionM = 2, nombre = "Dias", simbolo = "dd", estado = 1 },
                new gm_medicionM { idMedicionM = 3, nombre = "Meses", simbolo = "mm", estado = 1 },
                new gm_medicionM { idMedicionM = 4, nombre = "Años", simbolo = "aa", estado = 1 },
                new gm_medicionM { idMedicionM = 5, nombre = "Litros", simbolo = "L", estado = 1 },
                new gm_medicionM { idMedicionM = 6, nombre = "Galones", simbolo = "gal", estado = 1 },
                new gm_medicionM { idMedicionM = 7, nombre = "Sin Especificar", simbolo = "NaN", estado = 1 }
                );

            modelBuilder.Entity<gm_eventoM>().HasData(
                new gm_eventoM { idEventoM = 1, nombre = "Cuando sea necesario", estado = 1, isUnique = true, isOne= false },
                new gm_eventoM { idEventoM = 2, nombre = "Diariamente", estado = 1, isUnique = true, isOne = false },
                new gm_eventoM { idEventoM = 3, nombre = "Primeras", estado = 1, isUnique = false, isOne = true },
                new gm_eventoM { idEventoM = 4, nombre = "Cada", estado = 1, isUnique = false, isOne = false }
                );

            modelBuilder.Entity<gm_intervaloM>().HasData(
                //real
                new gm_intervaloM { idIntervaloM = 1, planMantenimientoId = 1, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 2, planMantenimientoId = 1, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 3, planMantenimientoId = 1, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 4, planMantenimientoId = 1, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 5, planMantenimientoId = 1, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 6, planMantenimientoId = 2, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 7, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 8, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 9, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 10, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 11, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 12, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 13, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 14, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 15, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 16, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 17, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 18, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 19, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 20, planMantenimientoId = 4, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 21, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 22, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 23, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 24, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 25, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 26, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 27, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 28, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 29, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 30, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 31, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 32, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 33, planMantenimientoId = 3, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 34, planMantenimientoId = 3, estadoActivado = true },

                new gm_intervaloM { idIntervaloM = 35, planMantenimientoId = 5, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 36, planMantenimientoId = 5, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 37, planMantenimientoId = 5, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 38, planMantenimientoId = 5, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 39, planMantenimientoId = 5, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 40, planMantenimientoId = 5, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 41, planMantenimientoId = 5, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 42, planMantenimientoId = 5, estadoActivado = true },
                new gm_intervaloM { idIntervaloM = 43, planMantenimientoId = 5, estadoActivado = true }
            );

            modelBuilder.Entity<gm_intervaloTarea>().HasData(
                //real
                new gm_intervaloTarea { idIntervaloTarea = 1, intervaloId = 1, tareaId = 7, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 2, intervaloId = 1, tareaId = 8, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 3, intervaloId = 1, tareaId = 9, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 4, intervaloId = 1, tareaId = 10, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 5, intervaloId = 2, tareaId = 11, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 6, intervaloId = 3, tareaId = 12, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 7, intervaloId = 3, tareaId = 13, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 8, intervaloId = 3, tareaId = 15, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 9, intervaloId = 3, tareaId = 16, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 10, intervaloId = 3, tareaId = 17, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 11, intervaloId = 3, tareaId = 18, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 12, intervaloId = 3, tareaId = 14, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 13, intervaloId = 4, tareaId = 22, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 14, intervaloId = 4, tareaId = 19, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 15, intervaloId = 4, tareaId = 20, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 16, intervaloId = 4, tareaId = 15, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 17, intervaloId = 4, tareaId = 12, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 18, intervaloId = 4, tareaId = 24, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 19, intervaloId = 4, tareaId = 25, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 20, intervaloId = 4, tareaId = 26, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 21, intervaloId = 4, tareaId = 27, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 22, intervaloId = 5, tareaId = 28, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 23, intervaloId = 5, tareaId = 29, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 24, intervaloId = 5, tareaId = 30, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 25, intervaloId = 5, tareaId = 31, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 26, intervaloId = 5, tareaId = 32, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 27, intervaloId = 6, tareaId = 7, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 28, intervaloId = 6, tareaId = 33, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 29, intervaloId = 6, tareaId = 34, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 30, intervaloId = 6, tareaId = 35, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 31, intervaloId = 6, tareaId = 17, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 32, intervaloId = 6, tareaId = 36, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 33, intervaloId = 6, tareaId = 37, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 34, intervaloId = 6, tareaId = 38, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 35, intervaloId = 6, tareaId = 39, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 36, intervaloId = 6, tareaId = 40, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 37, intervaloId = 6, tareaId = 41, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 38, intervaloId = 7, tareaId = 8, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 39, intervaloId = 7, tareaId = 35, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 40, intervaloId = 7, tareaId = 37, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 41, intervaloId = 7, tareaId = 42, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 42, intervaloId = 7, tareaId = 43, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 43, intervaloId = 8, tareaId = 44, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 44, intervaloId = 8, tareaId = 45, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 45, intervaloId = 8, tareaId = 46, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 46, intervaloId = 9, tareaId = 47, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 47, intervaloId = 10, tareaId = 3, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 48, intervaloId = 11, tareaId = 47, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 49, intervaloId = 12, tareaId = 48, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 50, intervaloId = 13, tareaId = 49, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 51, intervaloId = 14, tareaId = 50, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 52, intervaloId = 15, tareaId = 51, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 53, intervaloId = 15, tareaId = 52, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 54, intervaloId = 15, tareaId = 6, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 55, intervaloId = 16, tareaId = 53, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 56, intervaloId = 16, tareaId = 2, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 57, intervaloId = 16, tareaId = 54, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 58, intervaloId = 16, tareaId = 55, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 59, intervaloId = 16, tareaId = 4, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 60, intervaloId = 16, tareaId = 56, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 61, intervaloId = 16, tareaId = 57, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 62, intervaloId = 16, tareaId = 58, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 63, intervaloId = 16, tareaId = 59, estadoActivado = true }, 
                new gm_intervaloTarea { idIntervaloTarea = 64, intervaloId = 16, tareaId = 42, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 65, intervaloId = 16, tareaId = 60, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 66, intervaloId = 16, tareaId = 61, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 67, intervaloId = 16, tareaId = 62, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 68, intervaloId = 17, tareaId = 63, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 69, intervaloId = 17, tareaId = 64, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 70, intervaloId = 18, tareaId = 49, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 71, intervaloId = 19, tareaId = 65, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 72, intervaloId = 19, tareaId = 66, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 73, intervaloId = 19, tareaId = 67, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 74, intervaloId = 19, tareaId = 68, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 75, intervaloId = 19, tareaId = 69, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 76, intervaloId = 19, tareaId = 1, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 77, intervaloId = 19, tareaId = 51, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 78, intervaloId = 19, tareaId = 52, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 79, intervaloId = 19, tareaId = 6, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 80, intervaloId = 19, tareaId = 70, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 81, intervaloId = 20, tareaId = 71, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 82, intervaloId = 20, tareaId = 72, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 83, intervaloId = 20, tareaId = 73, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 84, intervaloId = 21, tareaId = 74, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 85, intervaloId = 21, tareaId = 75, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 86, intervaloId = 21, tareaId = 38, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 87, intervaloId = 21, tareaId = 8, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 88, intervaloId = 21, tareaId = 35, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 89, intervaloId = 21, tareaId = 36, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 90, intervaloId = 21, tareaId = 7, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 91, intervaloId = 21, tareaId = 37, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 92, intervaloId = 21, tareaId = 42, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 93, intervaloId = 21, tareaId = 76, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 94, intervaloId = 21, tareaId = 77, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 95, intervaloId = 22, tareaId = 1, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 96, intervaloId = 22, tareaId = 80, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 97, intervaloId = 22, tareaId = 6, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 98, intervaloId = 23, tareaId = 2, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 99, intervaloId = 23, tareaId = 54, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 100, intervaloId = 23, tareaId = 3, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 101, intervaloId = 23, tareaId = 55, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 102, intervaloId = 23, tareaId = 58, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 103, intervaloId = 23, tareaId = 59, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 104, intervaloId = 23, tareaId = 62, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 105, intervaloId = 24, tareaId = 47, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 106, intervaloId = 25, tareaId = 79, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 107, intervaloId = 26, tareaId = 4, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 108, intervaloId = 26, tareaId = 57, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 109, intervaloId = 26, tareaId = 81, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 110, intervaloId = 26, tareaId = 42, estadoActivado = true }, 
                new gm_intervaloTarea { idIntervaloTarea = 111, intervaloId = 26, tareaId = 60, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 112, intervaloId = 27, tareaId = 5, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 113, intervaloId = 27, tareaId = 68, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 114, intervaloId = 27, tareaId = 83, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 115, intervaloId = 27, tareaId = 84, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 116, intervaloId = 27, tareaId = 64, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 117, intervaloId = 28, tareaId = 85, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 118, intervaloId = 29, tareaId = 48, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 119, intervaloId = 30, tareaId = 86, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 120, intervaloId = 30, tareaId = 80, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 121, intervaloId = 30, tareaId = 6, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 122, intervaloId = 31, tareaId = 87, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 123, intervaloId = 31, tareaId = 88, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 124, intervaloId = 31, tareaId = 73, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 125, intervaloId = 32, tareaId = 87, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 126, intervaloId = 32, tareaId = 88, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 127, intervaloId = 32, tareaId = 1, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 128, intervaloId = 32, tareaId = 89, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 129, intervaloId = 32, tareaId = 70, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 130, intervaloId = 32, tareaId = 73, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 131, intervaloId = 33, tareaId = 90, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 132, intervaloId = 34, tareaId = 47, estadoActivado = true },

                new gm_intervaloTarea { idIntervaloTarea = 133, intervaloId = 35, tareaId = 59, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 134, intervaloId = 36, tareaId = 94, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 135, intervaloId = 37, tareaId = 17, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 136, intervaloId = 38, tareaId = 51, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 137, intervaloId = 38, tareaId = 95, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 138, intervaloId = 39, tareaId = 96, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 139, intervaloId = 39, tareaId = 2, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 140, intervaloId = 39, tareaId = 54, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 141, intervaloId = 39, tareaId = 3, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 142, intervaloId = 39, tareaId = 55, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 143, intervaloId = 39, tareaId = 57, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 144, intervaloId = 39, tareaId = 58, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 145, intervaloId = 39, tareaId = 59, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 146, intervaloId = 39, tareaId = 97, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 147, intervaloId = 39, tareaId = 42, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 148, intervaloId = 39, tareaId = 60, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 149, intervaloId = 39, tareaId = 62, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 150, intervaloId = 39, tareaId = 52, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 151, intervaloId = 40, tareaId = 81, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 152, intervaloId = 40, tareaId = 99, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 153, intervaloId = 41, tareaId = 78, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 154, intervaloId = 41, tareaId = 66, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 155, intervaloId = 41, tareaId = 48, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 156, intervaloId = 41, tareaId = 47, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 157, intervaloId = 41, tareaId = 67, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 158, intervaloId = 41, tareaId = 68, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 159, intervaloId = 41, tareaId = 69, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 160, intervaloId = 41, tareaId = 51, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 161, intervaloId = 41, tareaId = 52, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 162, intervaloId = 41, tareaId = 82, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 163, intervaloId = 41, tareaId = 64, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 164, intervaloId = 42, tareaId = 71, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 165, intervaloId = 42, tareaId = 22, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 166, intervaloId = 42, tareaId = 95, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 167, intervaloId = 42, tareaId = 70, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 168, intervaloId = 42, tareaId = 73, estadoActivado = true },
                new gm_intervaloTarea { idIntervaloTarea = 169, intervaloId = 43, tareaId = 50, estadoActivado = true }
            );

            modelBuilder.Entity<gm_tareaAccion>().HasData(
                //real
                new gm_tareaAccion { idTareaAccion = 1, intervaloTareaId = 1, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 2, intervaloTareaId = 2, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 3, intervaloTareaId = 3, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 4, intervaloTareaId = 4, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 5, intervaloTareaId = 5, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 6, intervaloTareaId = 6, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 7, intervaloTareaId = 7, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 8, intervaloTareaId = 8, accionId = 16, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 9, intervaloTareaId = 9, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 10, intervaloTareaId = 10, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 11, intervaloTareaId = 11, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 12, intervaloTareaId = 12, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 13, intervaloTareaId = 13, accionId = 16, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 14, intervaloTareaId = 14, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 15, intervaloTareaId = 15, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 16, intervaloTareaId = 16, accionId = 9, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 17, intervaloTareaId = 16, accionId = 17, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 18, intervaloTareaId = 17, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 19, intervaloTareaId = 18, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 20, intervaloTareaId = 19, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 21, intervaloTareaId = 20, accionId = 18, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 22, intervaloTareaId = 21, accionId = 18, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 23, intervaloTareaId = 22, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 24, intervaloTareaId = 23, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 25, intervaloTareaId = 24, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 26, intervaloTareaId = 25, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 27, intervaloTareaId = 26, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 28, intervaloTareaId = 27, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 29, intervaloTareaId = 28, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 30, intervaloTareaId = 29, accionId = 9, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 31, intervaloTareaId = 30, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 32, intervaloTareaId = 31, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 33, intervaloTareaId = 32, accionId = 6, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 34, intervaloTareaId = 33, accionId = 6, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 35, intervaloTareaId = 34, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 36, intervaloTareaId = 35, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 37, intervaloTareaId = 36, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 38, intervaloTareaId = 37, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 39, intervaloTareaId = 38, accionId = 6, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 40, intervaloTareaId = 39, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 41, intervaloTareaId = 40, accionId = 6, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 42, intervaloTareaId = 41, accionId = 9, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 43, intervaloTareaId = 42, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 44, intervaloTareaId = 43, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 45, intervaloTareaId = 43, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 46, intervaloTareaId = 44, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 47, intervaloTareaId = 44, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 48, intervaloTareaId = 45, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 49, intervaloTareaId = 45, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 50, intervaloTareaId = 46, accionId = 5, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 51, intervaloTareaId = 47, accionId = 5, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 52, intervaloTareaId = 48, accionId = 5, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 53, intervaloTareaId = 49, accionId = 19, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 54, intervaloTareaId = 50, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 55, intervaloTareaId = 51, accionId = 16, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 56, intervaloTareaId = 52, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 57, intervaloTareaId = 52, accionId = 18, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 58, intervaloTareaId = 53, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 59, intervaloTareaId = 54, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 60, intervaloTareaId = 54, accionId = 18, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 61, intervaloTareaId = 55, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 62, intervaloTareaId = 56, accionId = 6, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 63, intervaloTareaId = 57, accionId = 18, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 64, intervaloTareaId = 57, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 65, intervaloTareaId = 58, accionId = 6, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 66, intervaloTareaId = 58, accionId = 19, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 67, intervaloTareaId = 59, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 68, intervaloTareaId = 60, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 69, intervaloTareaId = 60, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 70, intervaloTareaId = 61, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 71, intervaloTareaId = 62, accionId = 5, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 72, intervaloTareaId = 63, accionId = 16, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 73, intervaloTareaId = 64, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 74, intervaloTareaId = 65, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 75, intervaloTareaId = 66, accionId = 9, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 76, intervaloTareaId = 67, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 77, intervaloTareaId = 67, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 78, intervaloTareaId = 68, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 79, intervaloTareaId = 69, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 80, intervaloTareaId = 70, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 81, intervaloTareaId = 70, accionId = 20, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 82, intervaloTareaId = 81, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 83, intervaloTareaId = 82, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 84, intervaloTareaId = 82, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 85, intervaloTareaId = 82, accionId = 20, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 86, intervaloTareaId = 83, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 87, intervaloTareaId = 84, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 88, intervaloTareaId = 85, accionId = 9, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 89, intervaloTareaId = 86, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 90, intervaloTareaId = 86, accionId = 20, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 91, intervaloTareaId = 87, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 92, intervaloTareaId = 88, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 93, intervaloTareaId = 89, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 94, intervaloTareaId = 90, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 95, intervaloTareaId = 91, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 96, intervaloTareaId = 92, accionId = 9, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 97, intervaloTareaId = 93, accionId = 9, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 98, intervaloTareaId = 94, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 99, intervaloTareaId = 95, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 100, intervaloTareaId = 95, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 101, intervaloTareaId = 96, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 102, intervaloTareaId = 97, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 103, intervaloTareaId = 97, accionId = 18, estadoActivado = true },         
                new gm_tareaAccion { idTareaAccion = 104, intervaloTareaId = 98, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 105, intervaloTareaId = 99, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 106, intervaloTareaId = 99, accionId = 18, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 107, intervaloTareaId = 99, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 108, intervaloTareaId = 100, accionId = 5, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 109, intervaloTareaId = 101, accionId = 20, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 110, intervaloTareaId = 101, accionId = 19, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 111, intervaloTareaId = 102, accionId = 5, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 112, intervaloTareaId = 103, accionId = 16, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 113, intervaloTareaId = 104, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 114, intervaloTareaId = 104, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 115, intervaloTareaId = 105, accionId = 5, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 116, intervaloTareaId = 106, accionId = 20, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 117, intervaloTareaId = 107, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 118, intervaloTareaId = 108, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 119, intervaloTareaId = 109, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 120, intervaloTareaId = 110, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 121, intervaloTareaId = 110, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 122, intervaloTareaId = 111, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 123, intervaloTareaId = 112, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 124, intervaloTareaId = 113, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 125, intervaloTareaId = 114, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 126, intervaloTareaId = 115, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 127, intervaloTareaId = 116, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 128, intervaloTareaId = 117, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 129, intervaloTareaId = 118, accionId = 19, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 130, intervaloTareaId = 119, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 131, intervaloTareaId = 120, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 132, intervaloTareaId = 121, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 133, intervaloTareaId = 121, accionId = 18, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 134, intervaloTareaId = 122, accionId = 4, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 135, intervaloTareaId = 122, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 136, intervaloTareaId = 123, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 137, intervaloTareaId = 124, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 138, intervaloTareaId = 125, accionId = 4, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 139, intervaloTareaId = 125, accionId = 1, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 140, intervaloTareaId = 126, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 141, intervaloTareaId = 127, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 142, intervaloTareaId = 127, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 143, intervaloTareaId = 128, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 144, intervaloTareaId = 129, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 145, intervaloTareaId = 130, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 146, intervaloTareaId = 131, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 147, intervaloTareaId = 132, accionId = 5, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 148, intervaloTareaId = 71, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 149, intervaloTareaId = 72, accionId = 16, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 150, intervaloTareaId = 73, accionId = 8, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 151, intervaloTareaId = 74, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 152, intervaloTareaId = 75, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 153, intervaloTareaId = 76, accionId = 2, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 154, intervaloTareaId = 76, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 155, intervaloTareaId = 77, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 156, intervaloTareaId = 77, accionId = 18, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 157, intervaloTareaId = 78, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 158, intervaloTareaId = 79, accionId = 15, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 159, intervaloTareaId = 79, accionId = 18, estadoActivado = true },
                new gm_tareaAccion { idTareaAccion = 160, intervaloTareaId = 80, accionId = 15, estadoActivado = true }
            );

            modelBuilder.Entity<gm_eventoMedicion>().HasData(
                //real
                new gm_eventoMedicion { idEventoMedicion = 1, intervaloId = 1, eventoId = 2, medicionId = 7, valor = null },
                new gm_eventoMedicion { idEventoMedicion = 2, intervaloId = 2, eventoId = 4, medicionId = 3, valor = 1 },
                new gm_eventoMedicion { idEventoMedicion = 3, intervaloId = 3, eventoId = 4, medicionId = 1, valor = 2000 },
                new gm_eventoMedicion { idEventoMedicion = 4, intervaloId = 4, eventoId = 4, medicionId = 1, valor = 8000 },
                new gm_eventoMedicion { idEventoMedicion = 5, intervaloId = 5, eventoId = 4, medicionId = 1, valor = 16000 },
                new gm_eventoMedicion { idEventoMedicion = 6, intervaloId = 6, eventoId = 2, medicionId = 7, valor = null },
                new gm_eventoMedicion { idEventoMedicion = 7, intervaloId = 7, eventoId = 2, medicionId = 7, valor = null },
                new gm_eventoMedicion { idEventoMedicion = 8, intervaloId = 8, eventoId = 4, medicionId = 1, valor = 50 },
                new gm_eventoMedicion { idEventoMedicion = 9, intervaloId = 8, eventoId = 4, medicionId = 2, valor = 7 },
                new gm_eventoMedicion { idEventoMedicion = 10, intervaloId = 9, eventoId = 3, medicionId = 1, valor = 500 },
                new gm_eventoMedicion { idEventoMedicion = 11, intervaloId = 10, eventoId = 4, medicionId = 1, valor = 500 },
                new gm_eventoMedicion { idEventoMedicion = 12, intervaloId = 11, eventoId = 4, medicionId = 4, valor = 1 },
                new gm_eventoMedicion { idEventoMedicion = 13, intervaloId = 12, eventoId = 4, medicionId = 1, valor = 6000 },
                new gm_eventoMedicion { idEventoMedicion = 14, intervaloId = 12, eventoId = 4, medicionId = 4, valor = 3 },
                new gm_eventoMedicion { idEventoMedicion = 15, intervaloId = 13, eventoId = 4, medicionId = 4, valor = 6 },
                new gm_eventoMedicion { idEventoMedicion = 16, intervaloId = 14, eventoId = 4, medicionId = 1, valor = 12000},
                new gm_eventoMedicion { idEventoMedicion = 17, intervaloId = 14, eventoId = 4, medicionId = 4, valor = 6 },
                new gm_eventoMedicion { idEventoMedicion = 18, intervaloId = 15, eventoId = 3, medicionId = 1, valor = 250 },
                new gm_eventoMedicion { idEventoMedicion = 19, intervaloId = 16, eventoId = 4, medicionId = 4, valor = 1 },
                new gm_eventoMedicion { idEventoMedicion = 20, intervaloId = 16, eventoId = 4, medicionId = 1, valor = 250 },
                new gm_eventoMedicion { idEventoMedicion = 21, intervaloId = 17, eventoId = 4, medicionId = 1, valor = 1000 },
                new gm_eventoMedicion { idEventoMedicion = 22, intervaloId = 18, eventoId = 4, medicionId = 1, valor = 1000 },
                new gm_eventoMedicion { idEventoMedicion = 23, intervaloId = 18, eventoId = 4, medicionId = 4, valor = 2 },
                new gm_eventoMedicion { idEventoMedicion = 24, intervaloId = 19, eventoId = 4, medicionId = 1, valor = 3000 },
                new gm_eventoMedicion { idEventoMedicion = 25, intervaloId = 20, eventoId = 4, medicionId = 1, valor = 5000 },
                new gm_eventoMedicion { idEventoMedicion = 26, intervaloId = 21, eventoId = 2, medicionId = 7, valor = 3 },
                new gm_eventoMedicion { idEventoMedicion = 27, intervaloId = 22, eventoId = 3, medicionId = 1, valor =  250},
                new gm_eventoMedicion { idEventoMedicion = 28, intervaloId = 23, eventoId = 4, medicionId = 1, valor = 250},
                new gm_eventoMedicion { idEventoMedicion = 29, intervaloId = 24, eventoId = 3, medicionId = 1, valor =  500},
                new gm_eventoMedicion { idEventoMedicion = 30, intervaloId = 25, eventoId = 4, medicionId = 1, valor =  500},
                new gm_eventoMedicion { idEventoMedicion = 31, intervaloId = 26, eventoId = 4, medicionId = 1, valor =  1000},
                new gm_eventoMedicion { idEventoMedicion = 32, intervaloId = 27, eventoId = 4, medicionId = 1, valor =  2000},
                new gm_eventoMedicion { idEventoMedicion = 33, intervaloId = 28, eventoId = 4, medicionId = 1, valor =  3000},
                new gm_eventoMedicion { idEventoMedicion = 34, intervaloId = 29, eventoId = 4, medicionId = 1, valor =  3000},
                new gm_eventoMedicion { idEventoMedicion = 35, intervaloId = 29, eventoId = 4, medicionId = 4, valor =  3},
                new gm_eventoMedicion { idEventoMedicion = 36, intervaloId = 30, eventoId = 4, medicionId = 1, valor =  4000},
                new gm_eventoMedicion { idEventoMedicion = 37, intervaloId = 31, eventoId = 4, medicionId = 1, valor =  6000},
                new gm_eventoMedicion { idEventoMedicion = 38, intervaloId = 32, eventoId = 4, medicionId = 1, valor =  6000},
                new gm_eventoMedicion { idEventoMedicion = 39, intervaloId = 32, eventoId = 4, medicionId = 4, valor =  6},
                new gm_eventoMedicion { idEventoMedicion = 40, intervaloId = 33, eventoId = 4, medicionId = 1, valor =  8000},
                new gm_eventoMedicion { idEventoMedicion = 41, intervaloId = 33, eventoId = 4, medicionId = 4, valor =  3},
                new gm_eventoMedicion { idEventoMedicion = 42, intervaloId = 34, eventoId = 4, medicionId = 4, valor =  1},
                
                new gm_eventoMedicion { idEventoMedicion = 43, intervaloId = 35, eventoId = 4, medicionId = 1, valor =  500},
                new gm_eventoMedicion { idEventoMedicion = 44, intervaloId = 36, eventoId = 4, medicionId = 4, valor =  1},
                new gm_eventoMedicion { idEventoMedicion = 45, intervaloId = 37, eventoId = 4, medicionId = 1, valor =  50},
                new gm_eventoMedicion { idEventoMedicion = 46, intervaloId = 38, eventoId = 3, medicionId = 1, valor =  250},
                new gm_eventoMedicion { idEventoMedicion = 47, intervaloId = 39, eventoId = 4, medicionId = 1, valor =  250},
                new gm_eventoMedicion { idEventoMedicion = 48, intervaloId = 39, eventoId = 4, medicionId = 3, valor =  1},
                new gm_eventoMedicion { idEventoMedicion = 49, intervaloId = 40, eventoId = 4, medicionId = 1, valor =  1000},
                new gm_eventoMedicion { idEventoMedicion = 50, intervaloId = 41, eventoId = 4, medicionId = 1, valor =  3000},
                new gm_eventoMedicion { idEventoMedicion = 51, intervaloId = 41, eventoId = 4, medicionId = 4, valor =  2},
                new gm_eventoMedicion { idEventoMedicion = 52, intervaloId = 42, eventoId = 4, medicionId = 1, valor =  5000},
                new gm_eventoMedicion { idEventoMedicion = 53, intervaloId = 43, eventoId = 4, medicionId = 1, valor =  6000},
                new gm_eventoMedicion { idEventoMedicion = 54, intervaloId = 43, eventoId = 4, medicionId = 4, valor =  6}
            );

            //real
            modelBuilder.Entity<gm_alerta>().HasData(
                new gm_alerta { idAlerta = 1, color = "#FF0000", rangoInicio = 100, rangoFin = 99999999, nivelPrioridad = 1, tipoMaquinaria="Motor" },
                new gm_alerta { idAlerta = 2, color = "#F2DE00", rangoInicio = 80, rangoFin = 89, nivelPrioridad = 2, tipoMaquinaria = "Motor" },
                new gm_alerta { idAlerta = 3, color = "#00FF00", rangoInicio = 40, rangoFin = 79, nivelPrioridad = 3, tipoMaquinaria = "Motor" },
                new gm_alerta { idAlerta = 4, color = "#1485CC", rangoInicio = 0, rangoFin = 39, nivelPrioridad = 4, tipoMaquinaria = "Motor" },
                new gm_alerta { idAlerta = 5, color = "#F08000", rangoInicio = 90, rangoFin = 99, nivelPrioridad = 2, tipoMaquinaria = "Motor" }
            );
        }

        public DbSet<gm_barco> gm_barcos { get; set; }
        public DbSet<gm_maquinaria> gm_maquinarias { get; set; }
        public DbSet<gm_barco_maquinaria> gm_barco_maquinarias { get; set; }
        public DbSet<gm_galeriaArchivoBarco> gm_galeriaArchivoBarcos { get; set; }

        public DbSet<gm_magnitud> gm_magnitudes { get; set; }
        public DbSet<gm_unidad> gm_unidades { get; set; }

        public DbSet<gm_detalleFichaM> gm_detalleFichasM { get; set;}
        public DbSet<gm_detalleCollection> gm_detalleCollection { get; set; }

        public DbSet<gm_item> gm_items { get; set; }
        public DbSet<gm_itemCategory> gm_itemCategories { get; set; }
        public DbSet<gm_item_itemCategory> gm_item_itemCategories { get; set; }

        public DbSet<gm_identidadM> gm_identidadMs { get; set; }

        public DbSet<gm_item_identidad> gm_item_identidades { get; set; }

        /*Mantenimiento*/
        public DbSet<gm_planMantenimiento> gm_planMantenimientos { get; set; }

        public DbSet<gm_intervaloM> gm_intervalosM { get; set; }

        public DbSet<gm_eventoM> gm_eventosM { get; set; }

        public DbSet<gm_medicionM> gm_medicionesM { get; set; }

        public DbSet<gm_intervaloTarea> gm_intervaloTareas { get; set; }

        public DbSet<gm_eventoMedicion> gm_eventoMediciones { get; set; }

        public DbSet<gm_tareaAccion> gm_tareaAcciones { get; set; }

        public DbSet<gm_tareaM> gm_tareasM { get; set; }

        public DbSet<gm_accionM> gm_accionesM { get; set; }


        public DbSet<gm_alerta> gm_alertas { get; set; }

        /*Ordenes*/
        public DbSet<gm_ordenTrabajoB> gm_ordenTrabajosB { get; set; }

        public DbSet<gm_tareaO> gm_tareasO { get; set; }

        public DbSet<gm_accionO> gm_accionesO { get; set; }

        public DbSet<gm_historialBM> gm_historialBMs { get; set; }

        public DbSet<gm_historialTaOrden> gm_historialTaOrdenes { get; set; }

        public DbSet<gm_galeriaArchivoOrden> gm_galeriaArchivoOrdenes { get; set; }
        /*Fin Ordenes*/

        public DbSet<gm_mensaje> gm_mensajes { get; set; }

        public DbSet<gm_notificacion> gm_notificaciones { get; set; }
    }
}
