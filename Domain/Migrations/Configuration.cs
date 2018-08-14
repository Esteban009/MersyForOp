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
            //2   NULL Alergolog�a (Alergia inmunol�gica) Es la especialidad que ve los fen�menos inmunol�gicos del organismo como: asma, rinitis, urticarias, fiebre de heno, reacciones a medicamentos, reacciones adversas a ciertos medicamentos.
            //3   NULL Dermatolog�a    Rama de la medicina que estudia las enfermedades de la piel, pelo y u�as, as� como sus diagn�sticos y tratamientos. Hoy en d�a la dermatolog�a tiene varias subespecialidades como: Dematolog�a Pedi�trica, Cirug�a Dermatol�gica, Dermatopatolog�a, Contactolog�a, etc.
            //4   NULL Dermatolog�a pedi�trica Manejo m�dico quir�rgico de enfermedades de la piel cabello y u�as enfocado a los ni�os.
            //5   NULL Endocrinolog�a  Estudio de las gl�ndulas de secreci�n interna.Esta especialidad abarca todas las enfermedades ocasionadas por trastornos hormonales, tales como: Diabetes Mellitus, enfermedades tiroideas, hipofisarias, paratiroideas, suprarrenales, alteraciones en el metabolismo de l�pidos, obesidad.
            //6   NULL Endoscop�a  Manejo m�dico que permite revisar, reparar, o realizar biopsias de tejidos por medio de una min�scula lamparita colocada al borde de un delgado alambre elaborado con fibra �ptica. Esto permite extender la vista del m�dico para detectar cualquier cambio de coloraci�n, la textura, posibles sangrados o la presencia de p�lipos o tumores en algunas partes del cuerpo.
            //7   NULL Endodoncia  Manejo quir�rgico de enfermedades de los nervios de las piezas dentales.
            //8   NULL Gastroenterolog�a   Estudia todo lo relacionado al est�mago e intestinos, como: c�ncer de est�mago, es�fago, colon, p�lipos, �lceras, gastritis, ves�cula, acidez, par�sitos, estre�imiento, etc.
            //9   NULL Gen�tica    Rama de la medicina que estudia y trata la reproducci�n, herencia, variaci�n y del conjunto de fen�menos y problemas relativos a la descendencia, ejemplo: historia cl�nica gen�tica y el �rbol geneal�gico, tamiz neonatal para detecci�n de enfermedades metab�licas, estudios cromos�micos en sangre perif�rica, m�dula �sea, y fibroblastos, estudios moleculares de DNA para algunos padecimientos.
            //10  NULL Geriatr�a   Especialidad que estudia los aspectos preventivos, cl�nicos y terap�uticos de los adultos mayores.
            //11  NULL Gerontolog�a    Estudia el envejecimiento atendiendo los aspectos biol�gicos, psicol�gicos y sociales, atienden de manera integral al paciente de edad avanzada.Ginecolog�a y Obstetricia Estudia todo lo relacionado con la salud de la mujer, desde el inicio de la menstruaci�n, control de natalidad, embarazo, menopausia, infertilidad, enfermedades del sistema reproductor, etc.
            //12  NULL Hematolog�a Especialidad que estudia todo lo relacionado con la sangre como: leucemia, anemias, hemostasia, hipoglicemia, trombos, coagulaci�n, hemofilia, etc.
            //13  NULL Algolog�a   Especialidad m�dica que estudia y trata el dolor en todas sus manifestaciones.
            //14  NULL Hemato-Oncolog�a    Estudio m�dico de enfermedades malignas en la sangre.
            //15  NULL Hepatolog�a Manejo m�dico de todo lo relacionado al h�gado.
            //16  NULL Imagenolog�a    Maneja todo tipo de im�genes como: radiograf�as, tomograf�a axial computarizada, resonancia magn�tica, fluoroscopia digital, ultrasonidos, mastograf�as, ecotomogramas 3D, etc.
            //17  NULL Infectolog�a    Estudia todo lo relacionado a las enfermedades infecciosas, tanto en su prevenci�n como su tratamiento.
            //19  NULL Inmunolog�a cl�nica y alergolog�a pedi�trica    Manejo m�dico encaminado al fortalecimiento del sistema de defensa en ni�os con infecciones de repetici�n y/ o infecciones severas.
            //20  NULL Medicina f�sica y de rehabilitaci�n Tratamiento mediante terapia f�sica de rehabilitaci�n de pacientes con enfermedades cr�nicas , traumatizados y quir�rgicos.
            //21  NULL Medicina Cr�tic Atiende pacientes en estado delicado internados en terapia intensiva, media y de cuidados prolongados.
            //22  NULL Medicina general Manejo m�dico integral del paciente.
            //23  NULL Medicina familiar Act�a como v�a de entrada del paciente y su familia al sistema de atenci�n a la salud. Integra las ciencias biol�gicas, sociales y de la conducta; su campo de acci�n se desarrolla sin distinci�n de edades, sexos, sistemas org�nicos y enfermedades.
            //24  NULL Anestesiolog�a  Especialidad m�dica que estudia los procedimientos, aparatos y materiales que pueden emplearse para la anestesia.
            //25  NULL Medicina del deporte    Incluye aquellas ramas te�ricas y pr�cticas de la medicina que investigan la influencia del ejercicio, el entrenamiento, en personas sanas, enfermas y de los deportistas. La medicina del deporte abarca desde la valoraci�n del estado de salud, capacitaci�n, atenci�n de lesiones, nutrici�n, control cient�fico del entrenamiento, etc.
            //26  NULL Medicina Nuclear Rama de la medicina en la que se utilizan las propiedades de materiales radiactivos y estables para investigar procesos fisiol�gicos y bioqu�micos normales y anormales, as� como para diagnosticar y tratar procesos patol�gicos que afectan al organismo.
            //27  NULL Medicina preventiva Tiene como objetivo principal, la de prevenir enfermedades, pero si �stas no se pueden evitar o ya est�n presentes, es importante diagnosticarlas tempranamente antes de que hagan da�o o m�s da�o.A trav�s de una evaluaci�n m�dica (Check - up), se identifican factores de riesgo.
            //28  NULL    Nefrolog�a  La Nefrolog�a es la rama de la Medicina Interna que estudia las m�ltiples alteraciones que afectan los l�quidos y los electrolitos del cuerpo as� como las enfermedades renales, su diagn�stico y tratamiento(Insuficiencia renal cr�nica).Incluye el estudio del equilibrio �cido - base y la hipertensi�n arterial, y el control de pacientes con di�lisis.As� como la preparaci�n necesaria para transplantes de ri��n.
            //29  NULL    Neonatolog�a    Especialidad que estudia todo lo relacionado con el reci�n nacido, desde que nace hasta el momento de darlo de alta.El neonat�logo brinda cuidados especiales a los beb�s prematuros, vigilando su desarrollo o complicaciones que pueda tener.
            //30  NULL    Neumolog�a  Especialidad que est� enfocada a todo lo relacionado con el sistema respiratorio, como: neumon�as, bronconeumon�as, c�ncer de pulm�n, fumadores, enfermedades inflamatorias del pulm�n, etc.
            //31  NULL    Neurocirug�a    Manejo quir�rgico de pacientes con enfermedades en cerebro, medula y nervios perif�ricos.
            //32  NULL    Neuroradiolog�a Realizaci�n e interpretaci�n de tomograf�as, resonancias magn�ticas y angiograf�as del cerebro y m�dula espinal.
            //33  NULL    Neurofisiolog�a Los estudios neurofisiol�gicos, son evaluaciones de la actividad el�ctrica del cerebro, de los nervios perif�ricos y m�sculos.La forma de evaluar las diferentes estructuras del sistema nervioso, es a trav�s de mediciones muy precisas de la actividad el�ctrica que continuamente se produce en este sistema.Algunos estudios pueden ser: electroencefalograma, electomolograf�a, laboratorio del sue�o, etc.
            //34  NULL    Neurolog�a  Especialidad que estudia el Sistema Nervioso Central como por ejemplo: migra�a, epilepsia, enfermedad vascular cerebral, demencias o padecimientos del sistema perif�rico como: neuropat�as diab�ticas, radiculopat�as(ci�tica), distrof�as, convulsiones, ataque cerebral, hidrocefalia, par�lisis cerebral, apoplejias, etc.
            //35  NULL    Angiolog�a y cirug�a vascular   Manejo m�dico de los vasos sangu�neos y linf�ticos.
            //36  NULL    Nutriolog�a El nutri�logo se encarga de evaluar y vigilar el estado nutricional de las personas.La funci�n del nutri�logo es muy importante para mantener la salud de todas las personas, a nivel preventivo y tambi�n a nivel correctivo.Hay ciertas enfermedades que deben ser controladas con medicamentos, nutrici�n y ejercicio como es el caso de la diabetes o la obesidad.
            //37  NULL    Odontolog�a Se encarga del diagn�stico, prevenci�n y tratamientos de problemas de la salud bucal.Se divide en varias especialidades, endodoncia, odontopediatr�a, ortodoncia, periodoncia.Revisi�n de la cavidad oral, ganglios linf�ticos, submaxilares y cervicales, as� como articulaci�n Temporo - mandibular.
            //38  NULL    Oftalmolog�a    Especialidad dedicada a la prevenci�n y tratamientos, tanto m�dicos como quir�rgicos, de todo lo relacionado al ojo y sus anexos(p�rpados, v�as lagrimales, �rbita, etc.) como: miop�a, astigmatismo, hipermetrop�a, cataratas, estrabismo, glaucoma, etc.
            //39  NULL    Oncolog�a   La oncolog�a es la especialidad de la medicina interna que se dedica al diagn�stico y tratamiento m�dico del c�ncer.
            //40  NULL    T�cnico Ortesista   El T�cnico Ortesista est� capacitado para desempe�arse en el �rea del dise�o y confecci�n de aparatos ortop�dicos, adecuados a cada paciente en particular seg�n sea la patolog�a invalidante.Los t�cnicos son capaces de aplicar, en el dise�o y confecci�n de una ortesis, los conocimientos cient�ficos, especialmente aquellos relacionados con anatom�a, biomec�nica, patolog�a ort�sica y rehabilitaci�n, y las habilidades t�cnicas necesarias para que el dise�o del aparato ortop�dico sea funcional y cumpla con el objetivo de rehabilitar al paciente, siguiendo las instrucciones del profesional m�dico tratante.
            //41  NULL    Ortopedia   Especialidad relacionada con patolog�as del sistema musculoesqu�letico(huesos, ligamentos, m�sculos, nervios y todo lo que forma la estructura del cuerpo humano), como: deformidades cong�nitas, problemas de crecimiento y problemas posturales, lesiones traum�ticas y deportivas, lesiones neuromusculares, infecciones, tumores, artritis osteoporosis, etc.
            //42  NULL    Otorrinolaringolog�a    Especialidad relacionada a todo lo referente al o�do, nariz, y laringe y sus enfermedades.
            //43  NULL    Patolog�a   Ciencia m�dica y especialidad pr�ctica que estudian todos los aspectos de la enfermedad, con referencia especial a la naturaleza esencial, las causas y el desarrollo de estados anormales y tambi�n a los cambios estructurales y funcionales que resultan de los procesos de la enfermedad.
            //44  NULL    Pediatr�a   Especialidad m�dica que se ocupa del estudio y tratamiento de los ni�os en estado de salud y enfermedad durante su desarrollo, desde el nacimiento hasta la adolescencia.
            //45  NULL    Perinatolog�a   Subespecialidad de la obstetricia que se ocupa del cuidado de la madre y el feto durante la gestaci�n, el parto y el alumbramiento, en particular cuando la madre y / o el feto est�n enfermos o corren riesgo de estarlo.
            //46  NULL    Audiolog�a, foniatr�a   Manejo m�dico de la voz y la audici�n(detecci�n, prevenci�n de patolog�a del lenguaje y la audici�n).
            //47  NULL    Proctolog�a Especialidad quir�rgica que se ocupa del ano y recto, y sus enfermedades.
            //48  NULL    Psicolog�a  Disciplina acad�mica y ciencia que se ocupa de la conducta del hombre y los animales, y de los procesos mentales y fisiol�gicos relacionados con ella.
            //49  NULL    Psiquiatr�a Medicina psiqui�trica.Especialidad m�dica que se ocupa de los trastornos mentales.Diagn�stico y tratamiento de las enfermedades mentales.
            //50  NULL    Quiropraxia Sistema de curaci�n, fundado en que las enfermedades reconocen por causas un trastorno del sistema nervioso y se corrigen por la manipulaci�n de los �rganos, especialmente reducci�n manual de subluxaciones vertebrales.
            //51  NULL    Radiolog�a  Realizaci�n e interpretaci�n de estudio de imagen como rayos x y tomograf�as.
            //52  NULL    Radioterapia    Radioactividad dirigida y controlada contra el c�ncer.
            //53  NULL    Rehabilitaci�n pulmonar Programa para personas con enfermedades pulmonares cr�nicas como: enfisema, bronquitis cr�nica, asma, bronquiectasia y enfermedad intersticial pulmonar.La mayor�a de los programas de rehabilitaci�n pulmonar incluyen control m�dico, educaci�n, apoyo emocional, ejercicio, re - entrenamiento respiratorio y terapia de nutrici�n.
            //54  NULL    Reumatolog�a    Especialidad que tiene relaci�n con los problemas m�sculo - esquel�tico(m�sculos, huesos, columna vertebral, etc) de predominio en las articulaciones.Adem�s enfermedades de tejido conjuntivo como: Lupus Eritematoso Sist�mico, Dermatomiositis, Polimiositis, Esclerodemia, S�ndrome de Sj�gren, Vasculitis, etc.
            //55  NULL    Traumatolog�a y ortopedia   Manejo m�dico y quir�rgico de pacientes con enfermedades o lesiones en las articulaciones huesos y m�sculos.
            //56  NULL    Traumatolog�a deportiva Manejo m�dico y quir�rgico de pacientes con lesiones de todo tipo, relacionadas con el la actividad f�sica(deportistas).
            //57  NULL    Bariatr�a   Manejo m�dico farmacol�gico de pacientes con sobrepeso.
            //58  NULL    Urolog�a    Manejo m�dico y quir�rgico de las enfermedades de ri�ones, ureteros, pr�stata, vejiga y uretra
            //59  NULL    Cardiolog�a Estudia el coraz�n, sus funciones y patolog�as.Una de sus funciones es la de prevenir problemas futuros en pacientes con alto riesgo de enfermedades cardiacas.La otra, es la de ayudar a solucionar los problemas de salud a aquellos pacientes que ya tienen o han tenido problemas cardiacos de gravedad, como un infarto al miocardio, hipertensi�n, insuficiencia cardiaca, etc.
            //60  NULL    Cirug�a pl�tica y reconstructiva    La Cirug�a Reconstructiva; dedicada a preservar la integridad y funcionalidad de diversas estructuras de cuerpo, lo mismo se encarga de reconstruir un labio leporino (hendido), una gl�ndula mamaria extirpada por c�ncer o una mano severamente traumatizada.La Cirug�a Est�tica o Cosm�tica; tienen como objetivo, mejorar y mantener en forma �ptima las diversas caracter�sticas de la cara y el cuerpo, dentro de un contexto de imagen y armon�a, individualizado para cada paciente.
            //61  NULL Coloproctolog�a Manejo m�dico de todo lo relacionado con el colon y el recto.

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
                new Continent { Code = "AF", Name = "�frica", Demonym = "African@" },
                new Continent { Code = "AN", Name = "Ant�rtida", Demonym = "Antartic@" },
                new Continent { Code = "EU", Name = "AEuropa", Demonym = "Europe@" },
                new Continent { Code = "OC", Name = "Ocean�a", Demonym = "Oceanic@" }
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
                new Insurance { Code = "CMD", Name = "ARS CMD (Colegio M�dico Dominicano)" },
                new Insurance { Code = "Bupa", Name = "Bupa Dominicana, S.A." },
                new Insurance { Code = "APSa", Name = "Compa�ia de Seguros APS, S.R.L." }
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
