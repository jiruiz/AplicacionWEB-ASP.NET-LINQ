﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AplicacionWEB
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="templateDB")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertCategorias(Categorias instance);
    partial void UpdateCategorias(Categorias instance);
    partial void DeleteCategorias(Categorias instance);
    partial void InsertServicios(Servicios instance);
    partial void UpdateServicios(Servicios instance);
    partial void DeleteServicios(Servicios instance);
    partial void InsertTurnos(Turnos instance);
    partial void UpdateTurnos(Turnos instance);
    partial void DeleteTurnos(Turnos instance);
    partial void InsertTurnosServicios(TurnosServicios instance);
    partial void UpdateTurnosServicios(TurnosServicios instance);
    partial void DeleteTurnosServicios(TurnosServicios instance);
    partial void InsertUsuarios(Usuarios instance);
    partial void UpdateUsuarios(Usuarios instance);
    partial void DeleteUsuarios(Usuarios instance);
    #endregion
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Categorias> Categorias
		{
			get
			{
				return this.GetTable<Categorias>();
			}
		}
		
		public System.Data.Linq.Table<Servicios> Servicios
		{
			get
			{
				return this.GetTable<Servicios>();
			}
		}
		
		public System.Data.Linq.Table<Turnos> Turnos
		{
			get
			{
				return this.GetTable<Turnos>();
			}
		}
		
		public System.Data.Linq.Table<TurnosServicios> TurnosServicios
		{
			get
			{
				return this.GetTable<TurnosServicios>();
			}
		}
		
		public System.Data.Linq.Table<Usuarios> Usuarios
		{
			get
			{
				return this.GetTable<Usuarios>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Categorias")]
	public partial class Categorias : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdCategoria;
		
		private string _Nombre;
		
		private string _Descripcion;
		
		private EntitySet<Servicios> _Servicios;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdCategoriaChanging(int value);
    partial void OnIdCategoriaChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnDescripcionChanging(string value);
    partial void OnDescripcionChanged();
    #endregion
		
		public Categorias()
		{
			this._Servicios = new EntitySet<Servicios>(new Action<Servicios>(this.attach_Servicios), new Action<Servicios>(this.detach_Servicios));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdCategoria", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdCategoria
		{
			get
			{
				return this._IdCategoria;
			}
			set
			{
				if ((this._IdCategoria != value))
				{
					this.OnIdCategoriaChanging(value);
					this.SendPropertyChanging();
					this._IdCategoria = value;
					this.SendPropertyChanged("IdCategoria");
					this.OnIdCategoriaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descripcion", DbType="NVarChar(255)")]
		public string Descripcion
		{
			get
			{
				return this._Descripcion;
			}
			set
			{
				if ((this._Descripcion != value))
				{
					this.OnDescripcionChanging(value);
					this.SendPropertyChanging();
					this._Descripcion = value;
					this.SendPropertyChanged("Descripcion");
					this.OnDescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Categorias_Servicios", Storage="_Servicios", ThisKey="IdCategoria", OtherKey="IdCategoria")]
		public EntitySet<Servicios> Servicios
		{
			get
			{
				return this._Servicios;
			}
			set
			{
				this._Servicios.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Servicios(Servicios entity)
		{
			this.SendPropertyChanging();
			entity.Categorias = this;
		}
		
		private void detach_Servicios(Servicios entity)
		{
			this.SendPropertyChanging();
			entity.Categorias = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Servicios")]
	public partial class Servicios : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdServicio;
		
		private string _Nombre;
		
		private string _Descripcion;
		
		private int _DuracionMinutos;
		
		private decimal _Precio;
		
		private bool _Estado;
		
		private System.Nullable<int> _IdCategoria;
		
		private EntitySet<TurnosServicios> _TurnosServicios;
		
		private EntityRef<Categorias> _Categorias;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdServicioChanging(int value);
    partial void OnIdServicioChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnDescripcionChanging(string value);
    partial void OnDescripcionChanged();
    partial void OnDuracionMinutosChanging(int value);
    partial void OnDuracionMinutosChanged();
    partial void OnPrecioChanging(decimal value);
    partial void OnPrecioChanged();
    partial void OnEstadoChanging(bool value);
    partial void OnEstadoChanged();
    partial void OnIdCategoriaChanging(System.Nullable<int> value);
    partial void OnIdCategoriaChanged();
    #endregion
		
		public Servicios()
		{
			this._TurnosServicios = new EntitySet<TurnosServicios>(new Action<TurnosServicios>(this.attach_TurnosServicios), new Action<TurnosServicios>(this.detach_TurnosServicios));
			this._Categorias = default(EntityRef<Categorias>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdServicio", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdServicio
		{
			get
			{
				return this._IdServicio;
			}
			set
			{
				if ((this._IdServicio != value))
				{
					this.OnIdServicioChanging(value);
					this.SendPropertyChanging();
					this._IdServicio = value;
					this.SendPropertyChanged("IdServicio");
					this.OnIdServicioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descripcion", DbType="NVarChar(255)")]
		public string Descripcion
		{
			get
			{
				return this._Descripcion;
			}
			set
			{
				if ((this._Descripcion != value))
				{
					this.OnDescripcionChanging(value);
					this.SendPropertyChanging();
					this._Descripcion = value;
					this.SendPropertyChanged("Descripcion");
					this.OnDescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DuracionMinutos", DbType="Int NOT NULL")]
		public int DuracionMinutos
		{
			get
			{
				return this._DuracionMinutos;
			}
			set
			{
				if ((this._DuracionMinutos != value))
				{
					this.OnDuracionMinutosChanging(value);
					this.SendPropertyChanging();
					this._DuracionMinutos = value;
					this.SendPropertyChanged("DuracionMinutos");
					this.OnDuracionMinutosChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Precio", DbType="Decimal(10,2) NOT NULL")]
		public decimal Precio
		{
			get
			{
				return this._Precio;
			}
			set
			{
				if ((this._Precio != value))
				{
					this.OnPrecioChanging(value);
					this.SendPropertyChanging();
					this._Precio = value;
					this.SendPropertyChanged("Precio");
					this.OnPrecioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estado", DbType="Bit NOT NULL")]
		public bool Estado
		{
			get
			{
				return this._Estado;
			}
			set
			{
				if ((this._Estado != value))
				{
					this.OnEstadoChanging(value);
					this.SendPropertyChanging();
					this._Estado = value;
					this.SendPropertyChanged("Estado");
					this.OnEstadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdCategoria", DbType="Int")]
		public System.Nullable<int> IdCategoria
		{
			get
			{
				return this._IdCategoria;
			}
			set
			{
				if ((this._IdCategoria != value))
				{
					if (this._Categorias.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdCategoriaChanging(value);
					this.SendPropertyChanging();
					this._IdCategoria = value;
					this.SendPropertyChanged("IdCategoria");
					this.OnIdCategoriaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Servicios_TurnosServicios", Storage="_TurnosServicios", ThisKey="IdServicio", OtherKey="IdServicio")]
		public EntitySet<TurnosServicios> TurnosServicios
		{
			get
			{
				return this._TurnosServicios;
			}
			set
			{
				this._TurnosServicios.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Categorias_Servicios", Storage="_Categorias", ThisKey="IdCategoria", OtherKey="IdCategoria", IsForeignKey=true)]
		public Categorias Categorias
		{
			get
			{
				return this._Categorias.Entity;
			}
			set
			{
				Categorias previousValue = this._Categorias.Entity;
				if (((previousValue != value) 
							|| (this._Categorias.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Categorias.Entity = null;
						previousValue.Servicios.Remove(this);
					}
					this._Categorias.Entity = value;
					if ((value != null))
					{
						value.Servicios.Add(this);
						this._IdCategoria = value.IdCategoria;
					}
					else
					{
						this._IdCategoria = default(Nullable<int>);
					}
					this.SendPropertyChanged("Categorias");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_TurnosServicios(TurnosServicios entity)
		{
			this.SendPropertyChanging();
			entity.Servicios = this;
		}
		
		private void detach_TurnosServicios(TurnosServicios entity)
		{
			this.SendPropertyChanging();
			entity.Servicios = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Turnos")]
	public partial class Turnos : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdTurno;
		
		private System.DateTime _FechaTurno;
		
		private string _Estado;
		
		private System.Nullable<decimal> _ImporteTotal;
		
		private int _IdUsuario;
		
		private System.DateTime _FechaCita;
		
		private System.TimeSpan _HoraCita;
		
		private EntitySet<TurnosServicios> _TurnosServicios;
		
		private EntityRef<Usuarios> _Usuarios;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdTurnoChanging(int value);
    partial void OnIdTurnoChanged();
    partial void OnFechaTurnoChanging(System.DateTime value);
    partial void OnFechaTurnoChanged();
    partial void OnEstadoChanging(string value);
    partial void OnEstadoChanged();
    partial void OnImporteTotalChanging(System.Nullable<decimal> value);
    partial void OnImporteTotalChanged();
    partial void OnIdUsuarioChanging(int value);
    partial void OnIdUsuarioChanged();
    partial void OnFechaCitaChanging(System.DateTime value);
    partial void OnFechaCitaChanged();
    partial void OnHoraCitaChanging(System.TimeSpan value);
    partial void OnHoraCitaChanged();
    #endregion
		
		public Turnos()
		{
			this._TurnosServicios = new EntitySet<TurnosServicios>(new Action<TurnosServicios>(this.attach_TurnosServicios), new Action<TurnosServicios>(this.detach_TurnosServicios));
			this._Usuarios = default(EntityRef<Usuarios>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdTurno", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdTurno
		{
			get
			{
				return this._IdTurno;
			}
			set
			{
				if ((this._IdTurno != value))
				{
					this.OnIdTurnoChanging(value);
					this.SendPropertyChanging();
					this._IdTurno = value;
					this.SendPropertyChanged("IdTurno");
					this.OnIdTurnoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaTurno", DbType="DateTime NOT NULL")]
		public System.DateTime FechaTurno
		{
			get
			{
				return this._FechaTurno;
			}
			set
			{
				if ((this._FechaTurno != value))
				{
					this.OnFechaTurnoChanging(value);
					this.SendPropertyChanging();
					this._FechaTurno = value;
					this.SendPropertyChanged("FechaTurno");
					this.OnFechaTurnoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estado", DbType="VarChar(20)")]
		public string Estado
		{
			get
			{
				return this._Estado;
			}
			set
			{
				if ((this._Estado != value))
				{
					this.OnEstadoChanging(value);
					this.SendPropertyChanging();
					this._Estado = value;
					this.SendPropertyChanged("Estado");
					this.OnEstadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImporteTotal", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> ImporteTotal
		{
			get
			{
				return this._ImporteTotal;
			}
			set
			{
				if ((this._ImporteTotal != value))
				{
					this.OnImporteTotalChanging(value);
					this.SendPropertyChanging();
					this._ImporteTotal = value;
					this.SendPropertyChanged("ImporteTotal");
					this.OnImporteTotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdUsuario", DbType="Int NOT NULL")]
		public int IdUsuario
		{
			get
			{
				return this._IdUsuario;
			}
			set
			{
				if ((this._IdUsuario != value))
				{
					if (this._Usuarios.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdUsuarioChanging(value);
					this.SendPropertyChanging();
					this._IdUsuario = value;
					this.SendPropertyChanged("IdUsuario");
					this.OnIdUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaCita", DbType="Date NOT NULL")]
		public System.DateTime FechaCita
		{
			get
			{
				return this._FechaCita;
			}
			set
			{
				if ((this._FechaCita != value))
				{
					this.OnFechaCitaChanging(value);
					this.SendPropertyChanging();
					this._FechaCita = value;
					this.SendPropertyChanged("FechaCita");
					this.OnFechaCitaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoraCita", DbType="Time NOT NULL")]
		public System.TimeSpan HoraCita
		{
			get
			{
				return this._HoraCita;
			}
			set
			{
				if ((this._HoraCita != value))
				{
					this.OnHoraCitaChanging(value);
					this.SendPropertyChanging();
					this._HoraCita = value;
					this.SendPropertyChanged("HoraCita");
					this.OnHoraCitaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Turnos_TurnosServicios", Storage="_TurnosServicios", ThisKey="IdTurno", OtherKey="IdTurno")]
		public EntitySet<TurnosServicios> TurnosServicios
		{
			get
			{
				return this._TurnosServicios;
			}
			set
			{
				this._TurnosServicios.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuarios_Turnos", Storage="_Usuarios", ThisKey="IdUsuario", OtherKey="IdUsuario", IsForeignKey=true)]
		public Usuarios Usuarios
		{
			get
			{
				return this._Usuarios.Entity;
			}
			set
			{
				Usuarios previousValue = this._Usuarios.Entity;
				if (((previousValue != value) 
							|| (this._Usuarios.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Usuarios.Entity = null;
						previousValue.Turnos.Remove(this);
					}
					this._Usuarios.Entity = value;
					if ((value != null))
					{
						value.Turnos.Add(this);
						this._IdUsuario = value.IdUsuario;
					}
					else
					{
						this._IdUsuario = default(int);
					}
					this.SendPropertyChanged("Usuarios");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_TurnosServicios(TurnosServicios entity)
		{
			this.SendPropertyChanging();
			entity.Turnos = this;
		}
		
		private void detach_TurnosServicios(TurnosServicios entity)
		{
			this.SendPropertyChanging();
			entity.Turnos = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TurnosServicios")]
	public partial class TurnosServicios : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Nullable<int> _IdTurno;
		
		private int _IdServicio;
		
		private int _IdTurnosServicios;
		
		private int _IdUsuario;
		
		private EntityRef<Servicios> _Servicios;
		
		private EntityRef<Turnos> _Turnos;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdTurnoChanging(System.Nullable<int> value);
    partial void OnIdTurnoChanged();
    partial void OnIdServicioChanging(int value);
    partial void OnIdServicioChanged();
    partial void OnIdTurnosServiciosChanging(int value);
    partial void OnIdTurnosServiciosChanged();
    partial void OnIdUsuarioChanging(int value);
    partial void OnIdUsuarioChanged();
    #endregion
		
		public TurnosServicios()
		{
			this._Servicios = default(EntityRef<Servicios>);
			this._Turnos = default(EntityRef<Turnos>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdTurno", DbType="Int")]
		public System.Nullable<int> IdTurno
		{
			get
			{
				return this._IdTurno;
			}
			set
			{
				if ((this._IdTurno != value))
				{
					if (this._Turnos.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdTurnoChanging(value);
					this.SendPropertyChanging();
					this._IdTurno = value;
					this.SendPropertyChanged("IdTurno");
					this.OnIdTurnoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdServicio", DbType="Int NOT NULL")]
		public int IdServicio
		{
			get
			{
				return this._IdServicio;
			}
			set
			{
				if ((this._IdServicio != value))
				{
					if (this._Servicios.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdServicioChanging(value);
					this.SendPropertyChanging();
					this._IdServicio = value;
					this.SendPropertyChanged("IdServicio");
					this.OnIdServicioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdTurnosServicios", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdTurnosServicios
		{
			get
			{
				return this._IdTurnosServicios;
			}
			set
			{
				if ((this._IdTurnosServicios != value))
				{
					this.OnIdTurnosServiciosChanging(value);
					this.SendPropertyChanging();
					this._IdTurnosServicios = value;
					this.SendPropertyChanged("IdTurnosServicios");
					this.OnIdTurnosServiciosChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdUsuario", DbType="Int NOT NULL")]
		public int IdUsuario
		{
			get
			{
				return this._IdUsuario;
			}
			set
			{
				if ((this._IdUsuario != value))
				{
					this.OnIdUsuarioChanging(value);
					this.SendPropertyChanging();
					this._IdUsuario = value;
					this.SendPropertyChanged("IdUsuario");
					this.OnIdUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Servicios_TurnosServicios", Storage="_Servicios", ThisKey="IdServicio", OtherKey="IdServicio", IsForeignKey=true)]
		public Servicios Servicios
		{
			get
			{
				return this._Servicios.Entity;
			}
			set
			{
				Servicios previousValue = this._Servicios.Entity;
				if (((previousValue != value) 
							|| (this._Servicios.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Servicios.Entity = null;
						previousValue.TurnosServicios.Remove(this);
					}
					this._Servicios.Entity = value;
					if ((value != null))
					{
						value.TurnosServicios.Add(this);
						this._IdServicio = value.IdServicio;
					}
					else
					{
						this._IdServicio = default(int);
					}
					this.SendPropertyChanged("Servicios");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Turnos_TurnosServicios", Storage="_Turnos", ThisKey="IdTurno", OtherKey="IdTurno", IsForeignKey=true, DeleteRule="SET NULL")]
		public Turnos Turnos
		{
			get
			{
				return this._Turnos.Entity;
			}
			set
			{
				Turnos previousValue = this._Turnos.Entity;
				if (((previousValue != value) 
							|| (this._Turnos.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Turnos.Entity = null;
						previousValue.TurnosServicios.Remove(this);
					}
					this._Turnos.Entity = value;
					if ((value != null))
					{
						value.TurnosServicios.Add(this);
						this._IdTurno = value.IdTurno;
					}
					else
					{
						this._IdTurno = default(Nullable<int>);
					}
					this.SendPropertyChanged("Turnos");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuarios")]
	public partial class Usuarios : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdUsuario;
		
		private string _Nombre;
		
		private string _Apellido;
		
		private string _Telefono;
		
		private string _Email;
		
		private string _Usuario;
		
		private string _Contrasena;
		
		private System.Nullable<System.DateTime> _FechaNacimiento;
		
		private string _Rol;
		
		private System.Nullable<bool> _Activo;
		
		private System.Nullable<System.DateTime> _FechaRegistro;
		
		private EntitySet<Turnos> _Turnos;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdUsuarioChanging(int value);
    partial void OnIdUsuarioChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnApellidoChanging(string value);
    partial void OnApellidoChanged();
    partial void OnTelefonoChanging(string value);
    partial void OnTelefonoChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnUsuarioChanging(string value);
    partial void OnUsuarioChanged();
    partial void OnContrasenaChanging(string value);
    partial void OnContrasenaChanged();
    partial void OnFechaNacimientoChanging(System.Nullable<System.DateTime> value);
    partial void OnFechaNacimientoChanged();
    partial void OnRolChanging(string value);
    partial void OnRolChanged();
    partial void OnActivoChanging(System.Nullable<bool> value);
    partial void OnActivoChanged();
    partial void OnFechaRegistroChanging(System.Nullable<System.DateTime> value);
    partial void OnFechaRegistroChanged();
    #endregion
		
		public Usuarios()
		{
			this._Turnos = new EntitySet<Turnos>(new Action<Turnos>(this.attach_Turnos), new Action<Turnos>(this.detach_Turnos));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdUsuario", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdUsuario
		{
			get
			{
				return this._IdUsuario;
			}
			set
			{
				if ((this._IdUsuario != value))
				{
					this.OnIdUsuarioChanging(value);
					this.SendPropertyChanging();
					this._IdUsuario = value;
					this.SendPropertyChanged("IdUsuario");
					this.OnIdUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Apellido", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Apellido
		{
			get
			{
				return this._Apellido;
			}
			set
			{
				if ((this._Apellido != value))
				{
					this.OnApellidoChanging(value);
					this.SendPropertyChanging();
					this._Apellido = value;
					this.SendPropertyChanged("Apellido");
					this.OnApellidoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Telefono", DbType="VarChar(20)")]
		public string Telefono
		{
			get
			{
				return this._Telefono;
			}
			set
			{
				if ((this._Telefono != value))
				{
					this.OnTelefonoChanging(value);
					this.SendPropertyChanging();
					this._Telefono = value;
					this.SendPropertyChanged("Telefono");
					this.OnTelefonoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Usuario", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Usuario
		{
			get
			{
				return this._Usuario;
			}
			set
			{
				if ((this._Usuario != value))
				{
					this.OnUsuarioChanging(value);
					this.SendPropertyChanging();
					this._Usuario = value;
					this.SendPropertyChanged("Usuario");
					this.OnUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Contrasena", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Contrasena
		{
			get
			{
				return this._Contrasena;
			}
			set
			{
				if ((this._Contrasena != value))
				{
					this.OnContrasenaChanging(value);
					this.SendPropertyChanging();
					this._Contrasena = value;
					this.SendPropertyChanged("Contrasena");
					this.OnContrasenaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaNacimiento", DbType="Date")]
		public System.Nullable<System.DateTime> FechaNacimiento
		{
			get
			{
				return this._FechaNacimiento;
			}
			set
			{
				if ((this._FechaNacimiento != value))
				{
					this.OnFechaNacimientoChanging(value);
					this.SendPropertyChanging();
					this._FechaNacimiento = value;
					this.SendPropertyChanged("FechaNacimiento");
					this.OnFechaNacimientoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rol", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string Rol
		{
			get
			{
				return this._Rol;
			}
			set
			{
				if ((this._Rol != value))
				{
					this.OnRolChanging(value);
					this.SendPropertyChanging();
					this._Rol = value;
					this.SendPropertyChanged("Rol");
					this.OnRolChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Activo", DbType="Bit")]
		public System.Nullable<bool> Activo
		{
			get
			{
				return this._Activo;
			}
			set
			{
				if ((this._Activo != value))
				{
					this.OnActivoChanging(value);
					this.SendPropertyChanging();
					this._Activo = value;
					this.SendPropertyChanged("Activo");
					this.OnActivoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaRegistro", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaRegistro
		{
			get
			{
				return this._FechaRegistro;
			}
			set
			{
				if ((this._FechaRegistro != value))
				{
					this.OnFechaRegistroChanging(value);
					this.SendPropertyChanging();
					this._FechaRegistro = value;
					this.SendPropertyChanged("FechaRegistro");
					this.OnFechaRegistroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuarios_Turnos", Storage="_Turnos", ThisKey="IdUsuario", OtherKey="IdUsuario")]
		public EntitySet<Turnos> Turnos
		{
			get
			{
				return this._Turnos;
			}
			set
			{
				this._Turnos.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Turnos(Turnos entity)
		{
			this.SendPropertyChanging();
			entity.Usuarios = this;
		}
		
		private void detach_Turnos(Turnos entity)
		{
			this.SendPropertyChanging();
			entity.Usuarios = null;
		}
	}
}
#pragma warning restore 1591
