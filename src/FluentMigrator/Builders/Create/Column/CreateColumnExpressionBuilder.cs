#region License
// 
// Copyright (c) 2007-2009, Sean Chambers <schambers80@gmail.com>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System.Collections.Generic;
using System.Data;
using FluentMigrator.Expressions;
using FluentMigrator.Infrastructure;
using FluentMigrator.Model;

namespace FluentMigrator.Builders.Create.Column
{
	public class CreateColumnExpressionBuilder : ExpressionBuilderBase<CreateColumnExpression>,
		ICreateColumnOnTableSyntax,
		ICreateColumnOptionSyntax,
		ICreateColumnAsTypeOrInSchemaSyntax
	{
		private readonly IMigrationContext _context;

		public CreateColumnExpressionBuilder(CreateColumnExpression expression, IMigrationContext context)
			: base(expression)
		{
			_context = context;
		}

		public ICreateColumnAsTypeOrInSchemaSyntax OnTable(string name)
		{
			Expression.TableName = name;
			return this;
		}

		public ICreateColumnAsTypeSyntax InSchema(string schemaName)
		{
			Expression.SchemaName = schemaName;
			return this;
		}

		public ICreateColumnOptionSyntax AsAnsiString()
		{
			Expression.Column.Type = DbType.AnsiString;
			return this;
		}

		public ICreateColumnOptionSyntax AsAnsiString(int size)
		{
			Expression.Column.Type = DbType.AnsiString;
			Expression.Column.Size = size;
			return this;
		}

		public ICreateColumnOptionSyntax AsBinary()
		{
			Expression.Column.Type = DbType.Binary;
			return this;
		}

		public ICreateColumnOptionSyntax AsBinary(int size)
		{
			Expression.Column.Type = DbType.Binary;
			Expression.Column.Size = size;
			return this;
		}

		public ICreateColumnOptionSyntax AsBoolean()
		{
			Expression.Column.Type = DbType.Boolean;
			return this;
		}

		public ICreateColumnOptionSyntax AsByte()
		{
			Expression.Column.Type = DbType.Byte;
			return this;
		}

		public ICreateColumnOptionSyntax AsCurrency()
		{
			Expression.Column.Type = DbType.Currency;
			return this;
		}

		public ICreateColumnOptionSyntax AsDate()
		{
			Expression.Column.Type = DbType.Date;
			return this;
		}

		public ICreateColumnOptionSyntax AsDateTime()
		{
			Expression.Column.Type = DbType.DateTime;
			return this;
		}

		public ICreateColumnOptionSyntax AsDecimal()
		{
			Expression.Column.Type = DbType.Decimal;
			return this;
		}

		public ICreateColumnOptionSyntax AsDecimal(int size, int precision)
		{
			Expression.Column.Type = DbType.Decimal;
			Expression.Column.Size = size;
			Expression.Column.Precision = precision;
			return this;
		}

		public ICreateColumnOptionSyntax AsDouble()
		{
			Expression.Column.Type = DbType.Double;
			return this;
		}

		public ICreateColumnOptionSyntax AsFixedLengthString(int size)
		{
			Expression.Column.Type = DbType.StringFixedLength;
			Expression.Column.Size = size;
			return this;
		}

		public ICreateColumnOptionSyntax AsFixedLengthAnsiString(int size)
		{
			Expression.Column.Type = DbType.AnsiStringFixedLength;
			Expression.Column.Size = size;
			return this;
		}

		public ICreateColumnOptionSyntax AsFloat()
		{
			Expression.Column.Type = DbType.Single;
			return this;
		}

		public ICreateColumnOptionSyntax AsGuid()
		{
			Expression.Column.Type = DbType.Guid;
			return this;
		}

		public ICreateColumnOptionSyntax AsInt16()
		{
			Expression.Column.Type = DbType.Int16;
			return this;
		}

		public ICreateColumnOptionSyntax AsInt32()
		{
			Expression.Column.Type = DbType.Int32;
			return this;
		}

		public ICreateColumnOptionSyntax AsInt64()
		{
			Expression.Column.Type = DbType.Int64;
			return this;
		}

		public ICreateColumnOptionSyntax AsString()
		{
			Expression.Column.Type = DbType.String;
			return this;
		}

		public ICreateColumnOptionSyntax AsString(int size)
		{
			Expression.Column.Type = DbType.String;
			Expression.Column.Size = size;
			return this;
		}

		public ICreateColumnOptionSyntax AsTime()
		{
			Expression.Column.Type = DbType.Time;
			return this;
		}

		public ICreateColumnOptionSyntax AsXml()
		{
			Expression.Column.Type = DbType.Xml;
			return this;
		}

		public ICreateColumnOptionSyntax AsXml(int size)
		{
			Expression.Column.Type = DbType.Xml;
			Expression.Column.Size = size;
			return this;
		}

		public ICreateColumnOptionSyntax AsCustom(string customType)
		{
			Expression.Column.Type = null;
			Expression.Column.CustomType = customType;
			return this;
		}

		public ICreateColumnOptionSyntax WithDefaultValue(object value)
		{
			Expression.Column.DefaultValue = value;
			return this;
		}

		public ICreateColumnOptionSyntax ForeignKey()
		{
			Expression.Column.IsForeignKey = true;
			return this;
		}

		public ICreateColumnOptionSyntax Identity()
		{
			Expression.Column.IsIdentity = true;
			return this;
		}

		public ICreateColumnOptionSyntax Indexed()
		{
			Expression.Column.IsIndexed = true;
			return this;
		}

		public ICreateColumnOptionSyntax PrimaryKey()
		{
			Expression.Column.IsPrimaryKey = true;
			return this;
		}

        public ICreateColumnOptionSyntax PrimaryKey(string primaryKeyName)
        {
            Expression.Column.IsPrimaryKey = true;
            Expression.Column.PrimaryKeyName = primaryKeyName;
            return this;
        }

		public ICreateColumnOptionSyntax Nullable()
		{
			Expression.Column.IsNullable = true;
			return this;
		}

		public ICreateColumnOptionSyntax NotNullable()
		{
			Expression.Column.IsNullable = false;
			return this;
		}

		public ICreateColumnOptionSyntax Unique()
		{
			Expression.Column.IsUnique = true;
			return this;
		}

		public ICreateColumnOptionSyntax References(string foreignKeyName, string foreignTableName, IEnumerable<string> foreignColumnNames)
		{
			return References(foreignKeyName, null, foreignTableName, foreignColumnNames);
		}

		public ICreateColumnOptionSyntax References(string foreignKeyName, string foreignTableSchema, string foreignTableName, IEnumerable<string> foreignColumnNames)
		{
			var fk = new CreateForeignKeyExpression
			{
				ForeignKey = new ForeignKeyDefinition
				{
					Name = foreignKeyName,
					PrimaryTable = Expression.TableName,
					PrimaryTableSchema = Expression.SchemaName,
					ForeignTable = foreignTableName,
					ForeignTableSchema = foreignTableSchema
				}
			};

			fk.ForeignKey.PrimaryColumns.Add(Expression.Column.Name);
			foreach (var foreignColumnName in foreignColumnNames)
				fk.ForeignKey.ForeignColumns.Add(foreignColumnName);

			_context.Expressions.Add(fk);
			return this;
		}
	}
}