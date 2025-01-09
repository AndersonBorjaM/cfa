using System.Text.Json.Serialization;

namespace Domain.Request
{
    public class FiltersClientRequest
    {
        public FiltersClientRequest() { }
        /// <summary>
        /// Nombre de la propiedad por la cual se va a realizar el filtro en nomenclaruta Pascal Case
        /// </summary>
        [JsonPropertyName("nombrePropiedad")]
        public string PropertyName { get; set; }

        /// <summary>
        /// Valor por el cual se va a realizar el filtro
        /// </summary>
        [JsonPropertyName("valorPropiedad")]
        public string PropertyValue { get; set; }

        /// <summary>
        /// En el caso de que se quiera ordenar el listado de resultados se puede indicar el nombre de la propiedad por la cual se desea ordenar en nomenclatura Pascal Case
        /// </summary>
        [JsonPropertyName("ordernarPor")]
        public string PropertyOrderBy { get; set; }

        /// <summary>
        /// Se usa para indicar de que forma se va a ordenar el listado de resultados en el caso de que sea falso se ordena descendente
        /// </summary>
        [JsonPropertyName("ordenarAscendente")]
        public bool AscendingOrderBy { get; set; } = true;

        /// <summary>
        /// En el caso de que el tipo de propiedad sea fecha se requiere indicar el inicio del rango de fechas mediante este valor.
        /// </summary>
        [JsonPropertyName("fechaInicio")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// En el caso de que el tipo de propiedad sea fecha se requiere indicar el fin del rango de fechas mediante este valor.
        /// </summary>
        [JsonPropertyName("fechaFin")]
        public DateTime? EndDate { get; set; }

    }
}
