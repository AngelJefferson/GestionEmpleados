INSERT bd_gestion_empleados

INSERT INTO tb_cargos (nombre_cargo, activo_cargo) VALUES
('Gerente', 1),
('Analista', 1),
('Asistente', 1),
('Supervisor', 1),
('Diseñador', 1);


INSERT INTO tb_departamentos (nombre_departamento, activo_departamento) VALUES
('Ventas', 1),
('Marketing', 1),
('Recursos Humanos', 1),
('Financiero', 1),
('Compras', 1),
('Informática', 1);

INSERT INTO tb_empleados
(nombre_empleado, direccion_empleado, fecha_nacimiento_empleado, telefono_empleado, salario_empleado, id_departamento, id_cargo, activo_empleado)
VALUES
('Angel Sanchez','Santo Domingo','1999-04-20','81684165166',100000.00,6,2,1),
('Carlos Peña','Santiago','1987-03-14','01234567891',750000000.00,3,2,1),
('Lucía Morales','Santo Domingo','1992-11-05','12345678901',820000000.00,1,5,1),
('Marcos Tejada','La Vega','1990-07-19','98765432100',950000000.00,6,3,1),
('Elena Guzmán','San Cristóbal','1985-05-22','45678912345',720000000.00,2,1,1),
('Ricardo López','Puerto Plata','1993-09-10','32165498712',670000000.00,5,4,1),
('Patricia Vargas','Higüey','1989-01-27','78912345678',880000000.00,4,2,1),
('Daniel Romero','San Francisco','1991-08-15','15975348621',910000000.00,2,3,1),
('Sofía Castillo','La Romana','1996-06-03','75315984269',315984269.00,1,1,1),
('Juan Mejía','Santo Domingo','1984-12-30','95135746820',650000000.00,6,5,1),
('Verónica Reyes','Moca','1995-04-09','65498732145',990000000.00,3,4,1),
('Alberto Jiménez','Baní','1988-02-18','36925814700',730000000.00,4,1,1),
('Carla Fernández','Santiago','1994-07-21','85274196300',1000000000.00,2,2,1),
('Luis Santana','San Juan','1990-10-11','74185296312',870000000.00,5,3,0),
('Ana Paredes','Nagua','1997-03-07','96385274136',760000000.00,1,4,0),
('Jorge Torres','Santo Domingo','1986-09-23','25836914785',840000000.00,6,5,0),
('angelo','Barrio El Calvario','2000-07-06','8888889090',15000.00,1,2,0),
('Julio','Santo Domingo Oeste','2025-08-26','1635463134',800000.00,6,1,0),
('jose miguel estevez','santo domingo este','2025-08-26','61354168426',100000.00,6,2,0),
('julio','santo domingo oseste','2025-08-28','874638438',84684684.00,6,1,0),
('radhy','santo domingo oeste','2025-08-29','86846384385',800000000.00,6,1,1),
('Jose Perez','Santo Domingo Norte','2026-03-02','6541631354',80000000.00,6,2,1);

