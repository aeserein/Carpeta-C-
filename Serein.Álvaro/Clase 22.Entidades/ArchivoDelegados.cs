namespace Clase_22.Entidades {

    public delegate void Delegado_LimiteSueldo(double sueldo, Empleado empleado);
    public delegate void Delegado_ConEventArgs(Empleado empleado, EmpleadoEventArgs ea);

    public enum TipoManejador {
        limiteSueldo,
        limiteSueldoMejorado,
        Todos
    }
}