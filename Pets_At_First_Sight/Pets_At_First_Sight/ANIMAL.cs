﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets_At_First_Sight
{
    class ANIMAL
    {
        private String _Nome;
		private String _Raca;
		private String _Idade;
        private String _Genero;
		private String _User_name;
		private String _Url_Image; //Comentar em BD

		//Fiz só esta para teste as restantes é a mesma lógica.

		public String Nome
		{
			get { return _Nome; }
			set { _Nome = value; }
		}


		public String Idade
		{
			get { return _Idade; }
			set
			{
				_Idade = value;
			}
		}

		public String Genero
		{
			get { return _Genero; }
			set { _Genero = value; }
		}

		public String Raca
		{
			get { return _Raca; }
			set { _Raca = value; }
		}
		public String Url_Image
		{
			get { return _Url_Image; }
			set { _Url_Image = value; }
		}
		public String User_Name
		{
			get { return _User_name; }
			set {_User_name = value; }
		}

	}
}