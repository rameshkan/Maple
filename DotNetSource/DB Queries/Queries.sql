
CREATE TABLE public.coverage_plan (
	id uuid NOT NULL,
	plan_name varchar(30) NOT NULL,
	elg_date_from date NOT NULL,
	elg_date_to date NOT NULL,
	elg_country varchar(5) NOT NULL DEFAULT '*'::character varying,
	CONSTRAINT coverage_plan_un UNIQUE (id)
);

CREATE TABLE public.rate_chart (
	id uuid NOT NULL,
	plan_id uuid NOT NULL,
	cust_gender varchar(1) NOT NULL,
	age int2 NOT NULL,
	"constraint" varchar(1) NOT NULL,
	net_price numeric NOT NULL,
	CONSTRAINT rate_chart_un UNIQUE (id)
);


CREATE TABLE public.rate_chart (
	id uuid NOT NULL,
	plan_id uuid NOT NULL,
	cust_gender varchar(1) NOT NULL,
	age int2 NOT NULL,
	"constraint" varchar(1) NOT NULL,
	net_price numeric NOT NULL,
	CONSTRAINT rate_chart_un UNIQUE (id)
);