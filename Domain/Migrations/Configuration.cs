namespace Domain.Migrations
{
    using Domain.GEN;
    using Domain.MED;
    using Domain.SEG;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Domain.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Domain.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //IList<Gender> defaultGenderList = new List<Gender>();

            //defaultGenderList.Add(new Gender() { Name = "M" });
            //defaultGenderList.Add(new Gender() { Name = "F" });
            //defaultGenderList.Add(new Gender() { Name = "I" });
            //foreach (var dtl in defaultGenderList)
            //    context.Genders.Add(dtl);

            ////Initializing the Gender list
            //IList<Currency> defaultCurrencyList = new List<Currency>();

            //defaultCurrencyList.Add(new Currency() { Code = "USD", Name = "Dollar" });
            //defaultCurrencyList.Add(new Currency() { Code = "DOP", Name = "Pesos Dominicanos" });
            //defaultCurrencyList.Add(new Currency() { Code = "EUR", Name = "Euro" });
            //foreach (var dtl in defaultCurrencyList)
            //    context.Currencies.Add(dtl);



            //base.Seed(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Status.AddOrUpdate(
                p => p.Name,
                new Status() { StatusId = 1, Name = "Activo", Table = "ALL" },
                new Status() { StatusId = 2, Name = "Inactivo", Table = "ALL" },
                new Status() { StatusId = 3, Name = "Caja Abierta", Table = "Cashier" },
                new Status() { StatusId = 4, Name = "Caja Cerrada", Table = "Cashier" },
                new Status() { StatusId = 5, Name = "Pagado", Table = "Sales" },
                new Status() { StatusId = 6, Name = "Pendiente de Pago", Table = "Sales" },
                new Status() { StatusId = 7, Name = "Pendiente de Pago (CxC)", Table = "Sales" },
                new Status() { StatusId = 8, Name = "Exonerado", Table = "Sales" },
                new Status() { StatusId = 9, Name = "Iniciado", Table = "Analitical" },
                new Status() { StatusId = 10, Name = "Listo Para Entrega", Table = "Analitical" },
                new Status() { StatusId = 11, Name = "Entregado", Table = "Analitical" }
            );
            //ID CODE    TABLA DESCRIPCION
            //10  A SOCIOS  Activo y al Dia
            //11  ACM SOCIOS  Atraso en Cuota de Membrecia
            //12  ACP SOCIOS  Atraso en Cuota de Prestamo
            //13  R SOCIOS  Retirado
            //14  F SOCIOS  Fallecido
            //15  I SOCIOS  Inactivo
            //16  A MIEMBROS    Activo y al Dia
            //19  R MIEMBROS    Retirado
            //20  F MIEMBROS    Fallecido
            //21  I MIEMBROS    Inactivo
            //ID CODIGO  NOMBRE DESCRIPCION TABLA_MODULO AUTORID
            //1   11  President@	Ser el Presidente de la fundacion   FUN 21
            //2   2   Secretario Ser el Secretario   FUN 21
            //3   3   Tesorero Ser el Tesorero FUN 21
            //4   033 Voluntario Miembro Voluntario FUN 21

            //CAT DE CUENTAS
            //ID CODIGO  NOMBRE DESCRIPCION BALANCE ORIGENID
            //1   100 ACTIVO NULL    0.00    1
            //2   200 PASIVO NULL    0.00 - 1
            //3   300 CAPITAL o PATRIMONIO NULL    0.00 - 1
            //4   400 INGRESOS NULL    0.00 - 1
            //5   500 COSTOS NULL    0.00    1
            //6   600 GASTOS NULL    0.00    1

            //EVENTOS CONTABLES
            //ID NOMBRE  DESCRIPCION CDISMINUYE1ID   CDISMINUYE2ID CDISMINUYE3ID   CAUMENTA1ID CAUMENTA2ID CAUMENTA3ID CAUMENTA4ID CDISMINUYE4ID ESTATUS
            //1   Venta al Contado Efectivo   1efectivo 29ingresoporventa 38compracostodeventa    38  NULL NULL    1   29  NULL NULL    NULL NULL
            //2   Venta al Contado Tarjeta    NULL NULL    NULL NULL    NULL NULL    NULL NULL    NULL NULL
            //3   Venta a Credito NULL    NULL NULL    NULL NULL    NULL NULL    NULL NULL    NULL
            //4   Venta Exonerada NULL NULL    NULL NULL    NULL NULL    NULL NULL    NULL NULL
            //5   Venta al Contado Cheque NULL NULL    NULL NULL    NULL NULL    NULL NULL    NULL NULL
            //6   Venta al Contado Cupon  NULL NULL    NULL NULL    NULL NULL    NULL NULL    NULL NULL

            //MOTIVOS CONTABLES
            //ID CODIGO  NOMBRE DESCRIPCION BALACT FECULTTRANS CATID AUTORID
            //1   111 Efectivo        0.00    NULL    1   NULL
            //2   112     Fondos en Bancos        0.00    NULL    1   NULL
            //3   113 Inversiones     0.00    NULL    1   NULL
            //4   114 Cuentas x Cobrar(Clientes)     0.00    NULL    1   NULL
            //5   115 Documentos x Cobrar     0.00    NULL    1   NULL
            //6   116 Inventario de Mercancia     0.00    NULL    1   NULL
            //7   121 Terrenos        0.00    NULL    1   NULL
            //8   122 Edificios       0.00    NULL    1   NULL
            //9   123 Mobiliario y Equipo de Oficina      0.00    NULL    1   NULL
            //10  124 Maquinaria y Equipo     0.00    NULL    1   NULL
            //11  131 Gastos de Organizacion e Instalacion        0.00    NULL    1   NULL
            //12  141 Depositos en Garantia       0.00    NULL    1   NULL
            //13  151 Estimacion para Cuentas Incobrables     0.00    NULL    1   NULL
            //14  201 Deudas a Corto Plazo        0.00    NULL    2   NULL
            //15  211 Proveedores     0.00    NULL    2   NULL
            //16  212 Documentos x Pagar      0.00    NULL    2   NULL
            //17  213 Acreedores Diversos     0.00    NULL    2   NULL
            //19  215 Retenciones Sociales        0.00    NULL    2   NULL
            //20  220 Deudas a Largo Plazo        0.00    NULL    2   NULL
            //21  221 Documentos x Pagar a Largo Plazo        0.00    NULL    2   NULL
            //22  301 Capital Contribuido     0.00    NULL    3   NULL
            //23  311 Capital Social      0.00    NULL    3   NULL
            //24  312 Donaciones      0.00    NULL    3   NULL
            //25  313 Reservas Estatutarias       0.00    NULL    3   NULL
            //26  320 Capital Ganado      0.00    NULL    3   NULL
            //27  321 Utilidades Acumuladas       0.00    NULL    3   NULL
            //28  322 Perdidas Acumuladas     0.00    NULL    3   NULL
            //29  411 Ingreso x Venta     0.00    NULL    4   NULL
            //30  412 Ingresos Financieros        0.00    NULL    4   NULL
            //31  413 Otros Ingresos      0.00    NULL    4   NULL
            //32  501 xxxxxxxxx       0.00    NULL    5   NULL
            //33  510 Rebajas Sobre Compras       0.00    NULL    5   NULL
            //34  511 Costo de Venta      0.00    NULL    5   NULL
            //35  515 Devoluciones Sobre Compras      0.00    NULL    5   NULL
            //36  520 Productos Financieros       0.00    NULL    5   NULL
            //37  525 Otros Productos     0.00    NULL    5   NULL
            //38  611 Compras / Costo de Venta      0.00    NULL    6   NULL
            //39  612 Gastos Sobre las Compras        0.00    NULL    6   NULL
            //40  613 Rebajas Sobre las Compras       0.00    NULL    6   NULL
            //41  614 Devoluciones Sobre las Ventas       0.00    NULL    6   NULL
            //42  620 Gasto de Administracion     0.00    NULL    6   NULL
            //43  630 Gasto de Venta      0.00    NULL    6   NULL
            //44  640 Gastos Financieros      0.00    NULL    6   NULL
            //45  650 Otros Gastos        0.00    NULL    6   NULL
            //47  111 Efectivo        0.00    NULL    1   21
            //48  112     Bancos      0.00    NULL    1   21
            //50  114 Cuentas x Cobrar(Miembros)     0.00    NULL    1   21
            //55  123 Mobiliario y Equipo de Oficina      0.00    NULL    1   21
            //62  212 Documentos x Pagar      0.00    NULL    2   21
            //66  220 Deudas a Largo Plazo        0.00    NULL    2   21
            //68  301 Capital Contribuido     0.00    NULL    3   21
            //69  311 Capital Social      0.00    NULL    3   21
            //70  312 Donaciones(Realizadas)     0.00    NULL    3   21
            //71  313 Reservas Estatutarias       0.00    NULL    3   21
            //72  320 Capital Ganado      0.00    NULL    3   21
            //75  411 Ingresos Generales      0.00    NULL    4   21
            //77  413 Ingreso x Donaciones        0.00    NULL    4   21
            //88  620 Gasto de Administracion     0.00    NULL    6   21
            //91  650 Otros Gastos        0.00    NULL    6   21
            //94  640 Impuestos Consulares    NULL    0.00    NULL    6   21
            //95  641 Pago de Evento NULL    0.00    NULL    6   21
            //96  111 Efectivo        0.00    NULL    1   22
            //97  112     Bancos      0.00    NULL    1   22
            //98  114 Cuentas x Cobrar(Clientes)     0.00    NULL    1   22
            //99  123 Mobiliario y Equipo de Oficina      0.00    NULL    1   22
            //100 212 Documentos x Pagar      0.00    NULL    2   22
            //101 220 Deudas a Largo Plazo        0.00    NULL    2   22
            //102 301 Capital Contribuido     0.00    NULL    3   22
            //103 311 Capital Social      0.00    NULL    3   22
            //104 312 Donaciones(Realizadas)     0.00    NULL    3   22
            //105 313 Reservas Estatutarias       0.00    NULL    3   22
            //106 320 Capital Ganado      0.00    NULL    3   22
            //107 411 Ingresos Generales      0.00    NULL    4   22
            //108 413 Ingreso x Donaciones(Recibidas)        0.00    NULL    4   22
            //109 620 Gasto de Administracion     0.00    NULL    6   22
            //110 650 Otros Gastos        0.00    NULL    6   22
            //111 640 Impuestos NULL    0.00    NULL    6   22
            //112 641 Pago de Eventos NULL    0.00    NULL    6   22
            //123 201 Deudas a Corto Plazo        0.00    NULL    2   22
            //127 214 ITBIS x Pagar       0.00    NULL    2   22
            //138 411 Ingreso x Venta     0.00    NULL    4   22
            //142 510 Rebajas Sobre Compras       0.00    NULL    5   22
            //143 511 Costo de Venta      0.00    NULL    5   22
            //144 515 Devoluciones Sobre Compras      0.00    NULL    5   22
            //147 611 Compras / Costo de Venta      0.00    NULL    6   22
            //148 612 Gastos Sobre las Compras        0.00    NULL    6   22
            //149 613 Rebajas Sobre las Compras       0.00    NULL    6   22
            //150 614 Devoluciones Sobre las Ventas       0.00    NULL    6   22
            //152 630 Gasto de Venta      0.00    NULL    6   22

            //FORMA DE PAGO
            //ID CODIGO  NOMBRE MONTO_MIN
            //1   N / A No Aplica   1.00
            //2   EF Efectivo    1.00
            //3   CH Cheque  1.00
            //4   TR Transferencia   100.00
            //5   TC Tarjeta de Credito  100.00
            //6   PP PayPal  1000.00
            //7   ND Nota de Debito  1.00
            //8   NC Nota de Credito 1.00
            //9   NC NULL    NULL

            //ESPECIALIDADES
            //ID CODIGO  DESCRIPCION NOTAS
            //1   NULL None    Significa que aun no tiene otra especialidad
            //2   NULL Alergología (Alergia inmunológica) Es la especialidad que ve los fenómenos inmunológicos del organismo como: asma, rinitis, urticarias, fiebre de heno, reacciones a medicamentos, reacciones adversas a ciertos medicamentos.
            //3   NULL Dermatología    Rama de la medicina que estudia las enfermedades de la piel, pelo y uñas, así como sus diagnósticos y tratamientos. Hoy en día la dermatología tiene varias subespecialidades como: Dematología Pediátrica, Cirugía Dermatológica, Dermatopatología, Contactología, etc.
            //4   NULL Dermatología pediátrica Manejo médico quirúrgico de enfermedades de la piel cabello y uñas enfocado a los niños.
            //5   NULL Endocrinología  Estudio de las glándulas de secreción interna.Esta especialidad abarca todas las enfermedades ocasionadas por trastornos hormonales, tales como: Diabetes Mellitus, enfermedades tiroideas, hipofisarias, paratiroideas, suprarrenales, alteraciones en el metabolismo de lípidos, obesidad.
            //6   NULL Endoscopía  Manejo médico que permite revisar, reparar, o realizar biopsias de tejidos por medio de una minúscula lamparita colocada al borde de un delgado alambre elaborado con fibra óptica. Esto permite extender la vista del médico para detectar cualquier cambio de coloración, la textura, posibles sangrados o la presencia de pólipos o tumores en algunas partes del cuerpo.
            //7   NULL Endodoncia  Manejo quirúrgico de enfermedades de los nervios de las piezas dentales.
            //8   NULL Gastroenterología   Estudia todo lo relacionado al estómago e intestinos, como: cáncer de estómago, esófago, colon, pólipos, úlceras, gastritis, vesícula, acidez, parásitos, estreñimiento, etc.
            //9   NULL Genética    Rama de la medicina que estudia y trata la reproducción, herencia, variación y del conjunto de fenómenos y problemas relativos a la descendencia, ejemplo: historia clínica genética y el árbol genealógico, tamiz neonatal para detección de enfermedades metabólicas, estudios cromosómicos en sangre periférica, médula ósea, y fibroblastos, estudios moleculares de DNA para algunos padecimientos.
            //10  NULL Geriatría   Especialidad que estudia los aspectos preventivos, clínicos y terapéuticos de los adultos mayores.
            //11  NULL Gerontología    Estudia el envejecimiento atendiendo los aspectos biológicos, psicológicos y sociales, atienden de manera integral al paciente de edad avanzada.Ginecología y Obstetricia Estudia todo lo relacionado con la salud de la mujer, desde el inicio de la menstruación, control de natalidad, embarazo, menopausia, infertilidad, enfermedades del sistema reproductor, etc.
            //12  NULL Hematología Especialidad que estudia todo lo relacionado con la sangre como: leucemia, anemias, hemostasia, hipoglicemia, trombos, coagulación, hemofilia, etc.
            //13  NULL Algología   Especialidad médica que estudia y trata el dolor en todas sus manifestaciones.
            //14  NULL Hemato-Oncología    Estudio médico de enfermedades malignas en la sangre.
            //15  NULL Hepatología Manejo médico de todo lo relacionado al hígado.
            //16  NULL Imagenología    Maneja todo tipo de imágenes como: radiografías, tomografía axial computarizada, resonancia magnética, fluoroscopia digital, ultrasonidos, mastografías, ecotomogramas 3D, etc.
            //17  NULL Infectología    Estudia todo lo relacionado a las enfermedades infecciosas, tanto en su prevención como su tratamiento.
            //19  NULL Inmunología clínica y alergología pediátrica    Manejo médico encaminado al fortalecimiento del sistema de defensa en niños con infecciones de repetición y/ o infecciones severas.
            //20  NULL Medicina física y de rehabilitación Tratamiento mediante terapia física de rehabilitación de pacientes con enfermedades crónicas , traumatizados y quirúrgicos.
            //21  NULL Medicina Crític Atiende pacientes en estado delicado internados en terapia intensiva, media y de cuidados prolongados.
            //22  NULL Medicina general Manejo médico integral del paciente.
            //23  NULL Medicina familiar Actúa como vía de entrada del paciente y su familia al sistema de atención a la salud. Integra las ciencias biológicas, sociales y de la conducta; su campo de acción se desarrolla sin distinción de edades, sexos, sistemas orgánicos y enfermedades.
            //24  NULL Anestesiología  Especialidad médica que estudia los procedimientos, aparatos y materiales que pueden emplearse para la anestesia.
            //25  NULL Medicina del deporte    Incluye aquellas ramas teóricas y prácticas de la medicina que investigan la influencia del ejercicio, el entrenamiento, en personas sanas, enfermas y de los deportistas. La medicina del deporte abarca desde la valoración del estado de salud, capacitación, atención de lesiones, nutrición, control científico del entrenamiento, etc.
            //26  NULL Medicina Nuclear Rama de la medicina en la que se utilizan las propiedades de materiales radiactivos y estables para investigar procesos fisiológicos y bioquímicos normales y anormales, así como para diagnosticar y tratar procesos patológicos que afectan al organismo.
            //27  NULL Medicina preventiva Tiene como objetivo principal, la de prevenir enfermedades, pero si éstas no se pueden evitar o ya están presentes, es importante diagnosticarlas tempranamente antes de que hagan daño o más daño.A través de una evaluación médica (Check - up), se identifican factores de riesgo.
            //28  NULL    Nefrología  La Nefrología es la rama de la Medicina Interna que estudia las múltiples alteraciones que afectan los líquidos y los electrolitos del cuerpo así como las enfermedades renales, su diagnóstico y tratamiento(Insuficiencia renal crónica).Incluye el estudio del equilibrio ácido - base y la hipertensión arterial, y el control de pacientes con diálisis.Así como la preparación necesaria para transplantes de riñón.
            //29  NULL    Neonatología    Especialidad que estudia todo lo relacionado con el recién nacido, desde que nace hasta el momento de darlo de alta.El neonatólogo brinda cuidados especiales a los bebés prematuros, vigilando su desarrollo o complicaciones que pueda tener.
            //30  NULL    Neumología  Especialidad que está enfocada a todo lo relacionado con el sistema respiratorio, como: neumonías, bronconeumonías, cáncer de pulmón, fumadores, enfermedades inflamatorias del pulmón, etc.
            //31  NULL    Neurocirugía    Manejo quirúrgico de pacientes con enfermedades en cerebro, medula y nervios periféricos.
            //32  NULL    Neuroradiología Realización e interpretación de tomografías, resonancias magnéticas y angiografías del cerebro y médula espinal.
            //33  NULL    Neurofisiología Los estudios neurofisiológicos, son evaluaciones de la actividad eléctrica del cerebro, de los nervios periféricos y músculos.La forma de evaluar las diferentes estructuras del sistema nervioso, es a través de mediciones muy precisas de la actividad eléctrica que continuamente se produce en este sistema.Algunos estudios pueden ser: electroencefalograma, electomolografía, laboratorio del sueño, etc.
            //34  NULL    Neurología  Especialidad que estudia el Sistema Nervioso Central como por ejemplo: migraña, epilepsia, enfermedad vascular cerebral, demencias o padecimientos del sistema periférico como: neuropatías diabéticas, radiculopatías(ciática), distrofías, convulsiones, ataque cerebral, hidrocefalia, parálisis cerebral, apoplejias, etc.
            //35  NULL    Angiología y cirugía vascular   Manejo médico de los vasos sanguíneos y linfáticos.
            //36  NULL    Nutriología El nutriólogo se encarga de evaluar y vigilar el estado nutricional de las personas.La función del nutriólogo es muy importante para mantener la salud de todas las personas, a nivel preventivo y también a nivel correctivo.Hay ciertas enfermedades que deben ser controladas con medicamentos, nutrición y ejercicio como es el caso de la diabetes o la obesidad.
            //37  NULL    Odontología Se encarga del diagnóstico, prevención y tratamientos de problemas de la salud bucal.Se divide en varias especialidades, endodoncia, odontopediatría, ortodoncia, periodoncia.Revisión de la cavidad oral, ganglios linfáticos, submaxilares y cervicales, así como articulación Temporo - mandibular.
            //38  NULL    Oftalmología    Especialidad dedicada a la prevención y tratamientos, tanto médicos como quirúrgicos, de todo lo relacionado al ojo y sus anexos(párpados, vías lagrimales, órbita, etc.) como: miopía, astigmatismo, hipermetropía, cataratas, estrabismo, glaucoma, etc.
            //39  NULL    Oncología   La oncología es la especialidad de la medicina interna que se dedica al diagnóstico y tratamiento médico del cáncer.
            //40  NULL    Técnico Ortesista   El Técnico Ortesista está capacitado para desempeñarse en el área del diseño y confección de aparatos ortopédicos, adecuados a cada paciente en particular según sea la patología invalidante.Los técnicos son capaces de aplicar, en el diseño y confección de una ortesis, los conocimientos científicos, especialmente aquellos relacionados con anatomía, biomecánica, patología ortésica y rehabilitación, y las habilidades técnicas necesarias para que el diseño del aparato ortopédico sea funcional y cumpla con el objetivo de rehabilitar al paciente, siguiendo las instrucciones del profesional médico tratante.
            //41  NULL    Ortopedia   Especialidad relacionada con patologías del sistema musculoesquéletico(huesos, ligamentos, músculos, nervios y todo lo que forma la estructura del cuerpo humano), como: deformidades congénitas, problemas de crecimiento y problemas posturales, lesiones traumáticas y deportivas, lesiones neuromusculares, infecciones, tumores, artritis osteoporosis, etc.
            //42  NULL    Otorrinolaringología    Especialidad relacionada a todo lo referente al oído, nariz, y laringe y sus enfermedades.
            //43  NULL    Patología   Ciencia médica y especialidad práctica que estudian todos los aspectos de la enfermedad, con referencia especial a la naturaleza esencial, las causas y el desarrollo de estados anormales y también a los cambios estructurales y funcionales que resultan de los procesos de la enfermedad.
            //44  NULL    Pediatría   Especialidad médica que se ocupa del estudio y tratamiento de los niños en estado de salud y enfermedad durante su desarrollo, desde el nacimiento hasta la adolescencia.
            //45  NULL    Perinatología   Subespecialidad de la obstetricia que se ocupa del cuidado de la madre y el feto durante la gestación, el parto y el alumbramiento, en particular cuando la madre y / o el feto están enfermos o corren riesgo de estarlo.
            //46  NULL    Audiología, foniatría   Manejo médico de la voz y la audición(detección, prevención de patología del lenguaje y la audición).
            //47  NULL    Proctología Especialidad quirúrgica que se ocupa del ano y recto, y sus enfermedades.
            //48  NULL    Psicología  Disciplina académica y ciencia que se ocupa de la conducta del hombre y los animales, y de los procesos mentales y fisiológicos relacionados con ella.
            //49  NULL    Psiquiatría Medicina psiquiátrica.Especialidad médica que se ocupa de los trastornos mentales.Diagnóstico y tratamiento de las enfermedades mentales.
            //50  NULL    Quiropraxia Sistema de curación, fundado en que las enfermedades reconocen por causas un trastorno del sistema nervioso y se corrigen por la manipulación de los órganos, especialmente reducción manual de subluxaciones vertebrales.
            //51  NULL    Radiología  Realización e interpretación de estudio de imagen como rayos x y tomografías.
            //52  NULL    Radioterapia    Radioactividad dirigida y controlada contra el cáncer.
            //53  NULL    Rehabilitación pulmonar Programa para personas con enfermedades pulmonares crónicas como: enfisema, bronquitis crónica, asma, bronquiectasia y enfermedad intersticial pulmonar.La mayoría de los programas de rehabilitación pulmonar incluyen control médico, educación, apoyo emocional, ejercicio, re - entrenamiento respiratorio y terapia de nutrición.
            //54  NULL    Reumatología    Especialidad que tiene relación con los problemas músculo - esquelético(músculos, huesos, columna vertebral, etc) de predominio en las articulaciones.Además enfermedades de tejido conjuntivo como: Lupus Eritematoso Sistémico, Dermatomiositis, Polimiositis, Esclerodemia, Síndrome de Sjögren, Vasculitis, etc.
            //55  NULL    Traumatología y ortopedia   Manejo médico y quirúrgico de pacientes con enfermedades o lesiones en las articulaciones huesos y músculos.
            //56  NULL    Traumatología deportiva Manejo médico y quirúrgico de pacientes con lesiones de todo tipo, relacionadas con el la actividad física(deportistas).
            //57  NULL    Bariatría   Manejo médico farmacológico de pacientes con sobrepeso.
            //58  NULL    Urología    Manejo médico y quirúrgico de las enfermedades de riñones, ureteros, próstata, vejiga y uretra
            //59  NULL    Cardiología Estudia el corazón, sus funciones y patologías.Una de sus funciones es la de prevenir problemas futuros en pacientes con alto riesgo de enfermedades cardiacas.La otra, es la de ayudar a solucionar los problemas de salud a aquellos pacientes que ya tienen o han tenido problemas cardiacos de gravedad, como un infarto al miocardio, hipertensión, insuficiencia cardiaca, etc.
            //60  NULL    Cirugía plática y reconstructiva    La Cirugía Reconstructiva; dedicada a preservar la integridad y funcionalidad de diversas estructuras de cuerpo, lo mismo se encarga de reconstruir un labio leporino (hendido), una glándula mamaria extirpada por cáncer o una mano severamente traumatizada.La Cirugía Estética o Cosmética; tienen como objetivo, mejorar y mantener en forma óptima las diversas características de la cara y el cuerpo, dentro de un contexto de imagen y armonía, individualizado para cada paciente.
            //61  NULL Coloproctología Manejo médico de todo lo relacionado con el colon y el recto.

            context.AuthorTypes.AddOrUpdate(
                p => p.Name,
                new AuthorType { Name = "Empresa" },
                new AuthorType { Name = "Persona" }
            );
            //  context.SaveChanges();
            context.Currencies.AddOrUpdate(
                p => p.Code,
                new Currency { CurrencyId = 1, Code = "DOP", Name = "Pesos Dominicanos" },
                new Currency { CurrencyId = 2, Code = "USD", Name = "Dollar" },
                new Currency { CurrencyId = 3, Code = "EUR", Name = "Euro" }
            );
            context.PaymentTypes.AddOrUpdate(
                p => p.Code,
                new PaymentType { Code = "Ef", Name = "Efectivo" },
                new PaymentType { Code = "CR", Name = "Credito" },
                new PaymentType { Code = "TC", Name = "Tarjeta de Credito" },
                new PaymentType { Code = "Ch", Name = "Cheque" },
                new PaymentType { Code = "Bn", Name = "Bonos" },
                new PaymentType { Code = "OC", Name = "Orden de Compra" },
                new PaymentType { Code = "On", Name = "Online" },
                new PaymentType { Code = "TE", Name = "Trasnferencia Electronica" }

            );
            //context.SaveChanges();
            context.BloodTypes.AddOrUpdate(
                p => p.Code,
                new BloodType { Code = "D", Name = "Desconocido" },
                new BloodType { Code = "O+", Name = "O+" },
                new BloodType { Code = "A+", Name = "A+" },
                new BloodType { Code = "B+", Name = "B+" },
                new BloodType { Code = "AB+", Name = "AB+" },
                new BloodType { Code = "O-", Name = "O-" },
                new BloodType { Code = "A-", Name = "A-" },
                new BloodType { Code = "B-", Name = "B-" },
                new BloodType { Code = "AB-", Name = "AB-" }
            );



            context.Continents.AddOrUpdate(
                p => p.Code,
                new Continent { Code = "AS", Name = "Asia", Demonym = "Asiatic@", },
                new Continent { Code = "AM", Name = "America", Demonym = "American@" },
                new Continent { Code = "AF", Name = "África", Demonym = "African@" },
                new Continent { Code = "AN", Name = "Antártida", Demonym = "Antartic@" },
                new Continent { Code = "EU", Name = "AEuropa", Demonym = "Europe@" },
                new Continent { Code = "OC", Name = "Oceanía", Demonym = "Oceanic@" }
            );
            context.Countries.AddOrUpdate(
                p => p.Code,
                new Country { Code = "RD", Name = "Republica Dominicana", Demonym = "Dominican@" },
                new Country { Code = "O", Name = "Otro", Demonym = "Estranjero" }
            );

            context.Periodicities.AddOrUpdate(
                p => p.Code,
                new Periodicity { PeriodicityId = 1, Code = "D", Name = "Diario" },
                new Periodicity { PeriodicityId = 2, Code = "W", Name = "Semanal" },
                new Periodicity { PeriodicityId = 3, Code = "Q", Name = "Quincenal" },
                new Periodicity { PeriodicityId = 4, Code = "M", Name = "Mensual" },
                new Periodicity { PeriodicityId = 5, Code = "B", Name = "Bimensual" },
                new Periodicity { PeriodicityId = 6, Code = "T", Name = "Trimestral" },
                new Periodicity { PeriodicityId = 7, Code = "C", Name = "Cuatrimestral" },
                new Periodicity { PeriodicityId = 8, Code = "S", Name = "Semestral" },
                new Periodicity { PeriodicityId = 9, Code = "A", Name = "Anual" },
                new Periodicity { PeriodicityId = 10, Code = "I", Name = "Irregular" },
                new Periodicity { PeriodicityId = 11, Code = "U", Name = "Unico" },
                new Periodicity { PeriodicityId = 12, Code = "N", Name = "Ninguno" }
            );
            // context.SaveChanges();
            context.Insurances.AddOrUpdate(
                p => p.Code,
                new Insurance { Code = "N/A", Name = "No Aplica/ Desconocido" },
                new Insurance { Code = "APS", Name = "ARS APS" },
                new Insurance { Code = "ASEMAP", Name = "ARS ASEMAP" },
                new Insurance { Code = "BMI", Name = "ARS BMI" },
                new Insurance { Code = "CMD", Name = "ARS CMD (Colegio Médico Dominicano)" },
                new Insurance { Code = "Bupa", Name = "Bupa Dominicana, S.A." },
                new Insurance { Code = "APSa", Name = "Compañia de Seguros APS, S.R.L." }
            );



            context.AuthorPlans.AddOrUpdate(
                p => p.Code,
                new AuthorPlan { Code = "TEST", Name = "Plan de Prueba", CurrencyId = 2, PeriodicityId = 11, Amount = 0, StatusId = 1 },
                new AuthorPlan { Code = "All", Name = "Plan All Power", CurrencyId = 2, PeriodicityId = 11, Amount = 0, StatusId = 1 }
            );

            //context.AuthorTypes.AddOrUpdate(
            //    p => p.Name,
            //    new AuthorType { Name = "Empresa" },
            //    new AuthorType { Name = "Persona" }
            //);
            // context.SaveChanges();
            context.Genders.AddOrUpdate(
                p => p.Name,
                new Gender { Name = "M" },
                new Gender { Name = "F" },
                new Gender { Name = "I" }
            );
            context.Ocupations.AddOrUpdate(
                p => p.Name,
                new Ocupation { Name = "N/A" },
                new Ocupation { Name = "Otr@" }
            );

            context.Religions.AddOrUpdate(
                p => p.Name,
                new Religion { Name = "N/A (Desconocida)" },
                new Religion { Name = "Catolic@" },
                new Religion { Name = "Evangelic@" },
                new Religion { Name = "Cristian@" },
                new Religion { Name = "Adventista" },
                new Religion { Name = "Testigo de Jehova" },
                new Religion { Name = "Mormon" },
                new Religion { Name = "Judio" },
                new Religion { Name = "Musulman" },
                new Religion { Name = "Hinduista" },
                new Religion { Name = "Budista" },
                new Religion { Name = "Taoista" },
                new Religion { Name = "Confusionista" },
                new Religion { Name = "Shintoista" },
                new Religion { Name = "Ate@" },
                new Religion { Name = "Otr@" }
            );

            context.SchoolLevels.AddOrUpdate(
                p => p.Name,
                new SchoolLevel { Name = "N/A (Desconocida)" },
                new SchoolLevel { Name = "Ninguno" },
                new SchoolLevel { Name = "Primaria" },
                new SchoolLevel { Name = "Secundaria" },
                new SchoolLevel { Name = "Tecnica" },
                new SchoolLevel { Name = "Universitaria" }
            );

            context.MaritalSituations.AddOrUpdate(
                p => p.Name,
                new MaritalSituation { Name = "N/A (Desconocido)" },
                new MaritalSituation { Name = "Solter@" },
                new MaritalSituation { Name = "Union Libre" },
                new MaritalSituation { Name = "Casad@" },
                new MaritalSituation { Name = "Divorciad@" },
                new MaritalSituation { Name = "Viud@" }
            );

            context.UserTypes.AddOrUpdate(
                p => p.Name,
                new UserType { Name = "Local" },
                new UserType { Name = "External" },
                new UserType { Name = "Facebook" },
                new UserType { Name = "Twitter" },
                new UserType { Name = "Microsoft" },
                new UserType { Name = "Google" }
            );
            //context.SaveChanges();
            //context.Authors.AddOrUpdate(
            //    p => p.Code,
            //    new Author { Code = "TEST", Name = "Test Empresa", Email = "sgermosen@praysoft.net", Tel = "8492077714", StatusId = 1,AuthorPlanId = 1, AuthorTypeId = 2 },
            //    new Author { Code = "TEST2", Name = "Test Persona", Email = "sgermosen@outlook.com", Tel = "8293495083",StatusId = 1,AuthorPlanId = 1, AuthorTypeId = 1 }
            //);
            //context.SaveChanges();
            context.BusinessTypes.AddOrUpdate(
                p => p.Name,
                new BusinessType { Name = "Comercial" },
                new BusinessType { Name = "Industrial" },
                new BusinessType { Name = "Servicios" },
                new BusinessType { Name = "Sociedad Colectiva" },
                new BusinessType { Name = "Sociedades Anonima" },
                new BusinessType { Name = "Unipersonales" }
            );



            context.ParentOptions.AddOrUpdate(
                p => p.Name,
                new ParentOption
                {
                    ParentOptionId = 1,
                    Name = "Seguridad",
                    Description = "Seguridad",
                    Link = "#menuSeguridad",
                    Order = 0,
                    Class = "fa fa-user",
                    Icon = "",
                    StatusId = 1
                },
                new ParentOption
                {
                    ParentOptionId = 2,
                    Name = "Configuracion Gen",
                    Description = "Configuracion Gen",
                    Link = "~/Manage",
                    Order = 1,
                    Class = "fa fa-cog",
                    Icon = "",
                    StatusId = 1
                },
                new ParentOption
                {
                    ParentOptionId = 3,
                    Name = "Pacientes",
                    Description = "Pacientes",
                    Link = "~/Medicals/Patients",
                    Order = 2,
                    Class = "fa fa-user-md",
                    Icon = "",
                    StatusId = 1
                },
                new ParentOption
                {
                    ParentOptionId = 4,
                    Name = "Control de Gastos",
                    Description = "Control de Gastos",
                    Link = "~/Expenses/Clasifications/Resume",
                    Order = 3,
                    Class = "fa fa-money",
                    Icon = "",
                    StatusId = 1
                },
                new ParentOption
                {
                    ParentOptionId = 5,
                    Name = "Administracion",
                    Description = "Administracion",
                    Link = "#menuconfigPos",
                    Order = 4,
                    Class = "fa fa-tasks",
                    Icon = "",
                    StatusId = 1
                },
                new ParentOption
                {
                    ParentOptionId = 6,
                    Name = "Operaciones",
                    Description = "Operaciones",
                    Link = "#menuconfig",
                    Order = 5,
                    Class = "fa fa-dollar",
                    Icon = "",
                    StatusId = 1
                },
                new ParentOption
                {
                    ParentOptionId = 7,
                    Name = "Configuracion Iguala",
                    Description = "Configuracion Iguala",
                    Link = "#menuconfig2",
                    Order = 6,
                    Class = "fa fa-cog",
                    Icon = "",
                    StatusId = 1
                });

            //  context.SaveChanges();



            context.Options.AddOrUpdate(
                p => p.Name,
                new Option
                {
                    ParentOptionId = 1,
                    Name = "Sucursales",
                    Description = "Sucursales",
                    Link = "#",
                    Area = "Pos",
                    Controller = "Shops",
                    Action = "Index",
                    Order = 0,
                    Class = "",
                    Icon = "",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 1,
                    Name = "Usuarios",
                    Description = "Usuarios",
                    Link = "#",
                    Area = "Pos",
                    Controller = "Users",
                    Action = "Index",
                    Order = 0,
                    Class = "",
                    Icon = "",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 1,
                    Name = "Roles",
                    Description = "Roles",
                    Link = "#",
                    Area = "Pos",
                    Controller = "Rols",
                    Action = "Index",
                    Order = 0,
                    Class = "",
                    Icon = "",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 2,
                    Name = "ReporteGeneral",
                    Description = "Reporte de Mi Negocio",
                    Link = "#",
                    Area = "Configurations",
                    Controller = "Reports",
                    Action = "Details",
                    Order = 0,
                    Class = "",
                    Icon = "",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 2,
                    Name = "ConfigSmtp",
                    Description = "Mi Configuracion Smtp",
                    Link = "#",
                    Area = "",
                    Controller = "Manage",
                    Action = "CreateSmtp",
                    Order = 0,
                    Class = "",
                    Icon = "",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Appointments",
                    Description = "Citas & Notificaciones",
                    Link = "~/Medicals/Patients/IndexAppointments/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexAppointments",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/appoint.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "General",
                    Description = "Consulta General",
                    Link = "~/Medicals/Patients/DetailsGeneral/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "DetailsGeneral",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/general.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Afections",
                    Description = "Hist. Diagnostica/Consultas",
                    Link = "~/Medicals/Patients/IndexGeneralAfections/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexGeneralAfections",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/cie.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "AnalyticalSheets",
                    Description = "Analitica (Pruebas de Lab.)",
                    Link = "~/Medicals/Patients/IndexAnalyticalSheets/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexAnalyticalSheets",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/lab.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Recipes",
                    Description = "Recetas",
                    Link = "~/Medicals/Patients/IndexRecipes/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexRecipes",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/receta.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "MedicalCertificates",
                    Description = "Certificado Medico",
                    Link = "~/Medicals/Patients/IndexMedicalCertificates/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexMedicalCertificates",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/licence.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Analytical",
                    Description = "Hist. Analitica (Resultados)",
                    Link = "~/Medicals/Patients/IndexAnalyticals/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexAnalyticals",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/histanalitic.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Treatment",
                    Description = "Hist. Terapeutica/Tratamientos",
                    Link = "~/Medicals/Patients/DetailsTreatment/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "DetailsTreatment",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/vacines.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Gynecology",
                    Description = "Hist. Ginecologica",
                    Link = "~/Medicals/Patients/DetailsGynecology/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "DetailsGynecology",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/ginecology.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Obstetrics",
                    Description = "Hist. Obstetrica (Pre Natal)",
                    Link = "~/Medicals/Patients/IndexObstetrics/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexObstetrics",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/obstetric.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Pediatric",
                    Description = "Hist. Pediatrica",
                    Link = "~/Medicals/Patients/DetailsPediatric/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "DetailsPediatric",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/pediatric.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Cardiologies",
                    Description = "Hist. Cardiologica",
                    Link = "~/Medicals/Patients/IndexCardiologies/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexCardiologies",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/cardiograma.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Endocrines",
                    Description = "Hist. Endocrino",
                    Link = "~/Medicals/Patients/IndexEndocrines/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexEndocrines",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/endocrine2.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Nutritions",
                    Description = "Hist. Nutricional",
                    Link = "~/Medicals/Patients/IndexNutritions/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexNutritions",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/diet.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Urologys",
                    Description = "Hist. Urologica",
                    Link = "~/Medicals/Patients/IndexUrologys/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexUrologys",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/urology.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Psychiatrys",
                    Description = "Hist. Psiquiatrica",
                    Link = "~/Medicals/Patients/IndexPsychiatrys/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexPsychiatrys",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/psiquiatric.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Orthopedics",
                    Description = "Hist. Ortopedica",
                    Link = "~/Medicals/Patients/IndexOrthopedics/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexOrthopedics",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/ortopeda.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Bariatrics",
                    Description = "Hist. Bariatrica",
                    Link = "~/Medicals/Patients/IndexBariatrics/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexBariatrics",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/bariatric.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Anesthetics",
                    Description = "Hist. Anestesica",
                    Link = "~/Medicals/Patients/IndexAnesthetics/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexAnesthetics",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/anestesia.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Surgeries",
                    Description = "Hist. Quirurgica",
                    Link = "~/Medicals/Patients/IndexSurgeries/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexSurgeries",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/surgery.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Patients",
                    Description = "Pacientes",
                    Link = "~/Medicals/Patients/Index/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "Index",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Reports",
                    Description = "Reportes",
                    Link = "~/Medicals/Patients/DetailsReport/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "DetailsReport",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "Inmunizations",
                    Description = "Vacunas e Inmunizaciones",
                    Link = "~/Medicals/Patients/IndexInmunizations/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexInmunizations",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "",
                    StatusId = 1
                }, new Option
                {
                    ParentOptionId = 3,
                    Name = "LaboratoryResultsOld",
                    Description = "Hist. Analitica (Resultados) Old",
                    Link = "~/Medicals/Patients/IndexLaboratoryResultsOld/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexLaboratoryResultsOld",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/histanaliticold.png",
                    StatusId = 1
                }, new Option
                {
                    ParentOptionId = 3,
                    Name = "IndexLaboratoryResults",
                    Description = "Hist. Analitica (Resultados) Am",
                    Link = "~/Medicals/Patients/IndexLaboratoryResults/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexLaboratoryResults",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/histanalitic.png",
                    StatusId = 1
                },
                new Option
                {
                    ParentOptionId = 3,
                    Name = "AnalyticalSheetsB",
                    Description = "Analitica Bar (Pruebas de Lab.)",
                    Link = "~/Medicals/Patients/IndexAnalyticalSheetsB/",
                    Area = "Medicals",
                    Controller = "Patients",
                    Action = "IndexAnalyticalSheetsB",
                    Order = 0,
                    Class = "btn btn-default",
                    Icon = "/Content/Icons/lab.png",
                    StatusId = 1
                }
            );
            context.SaveChanges();
        }
    }
}
