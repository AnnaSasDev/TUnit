"use strict";(self.webpackChunktunit_docs_site=self.webpackChunktunit_docs_site||[]).push([[6905],{7725:(e,t,r)=>{r.r(t),r.d(t,{assets:()=>c,contentTitle:()=>o,default:()=>d,frontMatter:()=>s,metadata:()=>i,toc:()=>u});var n=r(4848),a=r(8453);const s={sidebar_position:13},o="Data Source Generators",i={id:"tutorial-extras/data-source-generators",title:"Data Source Generators",description:"TUnit exposes an abstract DataSourceGeneratorAttribute class that you can inherit from and implement your own logic for creating values.",source:"@site/docs/tutorial-extras/data-source-generators.md",sourceDirName:"tutorial-extras",slug:"/tutorial-extras/data-source-generators",permalink:"/TUnit/docs/tutorial-extras/data-source-generators",draft:!1,unlisted:!1,tags:[],version:"current",sidebarPosition:13,frontMatter:{sidebar_position:13},sidebar:"tutorialSidebar",previous:{title:"Command Line Flags",permalink:"/TUnit/docs/tutorial-extras/command-line-flags"},next:{title:"Tutorial - Assertions",permalink:"/TUnit/docs/category/tutorial---assertions"}},c={},u=[];function l(e){const t={code:"code",h1:"h1",header:"header",p:"p",pre:"pre",...(0,a.R)(),...e.components};return(0,n.jsxs)(n.Fragment,{children:[(0,n.jsx)(t.header,{children:(0,n.jsx)(t.h1,{id:"data-source-generators",children:"Data Source Generators"})}),"\n",(0,n.jsxs)(t.p,{children:["TUnit exposes an ",(0,n.jsx)(t.code,{children:"abstract"})," ",(0,n.jsx)(t.code,{children:"DataSourceGeneratorAttribute"})," class that you can inherit from and implement your own logic for creating values."]}),"\n",(0,n.jsxs)(t.p,{children:["The ",(0,n.jsx)(t.code,{children:"DataSourceGeneratorAttribute"})," class uses generic ",(0,n.jsx)(t.code,{children:"Type"})," arguments to keep your data strongly typed."]}),"\n",(0,n.jsxs)(t.p,{children:["This attribute can be useful to easily populate data in a generic way, and without having to define lots of specific ",(0,n.jsx)(t.code,{children:"MethodDataSources"})]}),"\n",(0,n.jsxs)(t.p,{children:["If you just need to generate data for a single parameter, you simply return ",(0,n.jsx)(t.code,{children:"T"}),"."]}),"\n",(0,n.jsxs)(t.p,{children:["If you need to generate data for multiple parameters, you must use a ",(0,n.jsx)(t.code,{children:"Tuple<>"})," return type. E.g. ",(0,n.jsx)(t.code,{children:"return (T1, T2, T3)"})]}),"\n",(0,n.jsx)(t.p,{children:"Here's an example that uses AutoFixture to generate arguments:"}),"\n",(0,n.jsx)(t.pre,{children:(0,n.jsx)(t.code,{className:"language-csharp",children:"using TUnit.Core;\n\nnamespace MyTestProject;\n\npublic class AutoFixtureGeneratorAttribute<T1, T2, T3> : DataSourceGeneratorAttribute<T1, T2, T3>\n{\n    public override IEnumerable<(T1, T2, T3)> GenerateDataSources()\n    {\n        var fixture = new Fixture();\n        \n        yield return (fixture.Create<T1>(), fixture.Create<T2>(), fixture.Create<T3>());\n    }\n}\n\n[AutoFixtureGenerator<SomeClass1, SomeClass2, SomeClass3>]\npublic class MyTestClass(SomeClass1 someClass1, SomeClass2 someClass2, SomeClass3 someClass3)\n{\n    [Test]\n    [AutoFixtureGenerator<int, string, bool>]\n    public async Task Test((int value, string value2, bool value3))\n    {\n        // ...\n    }\n}\n"})})]})}function d(e={}){const{wrapper:t}={...(0,a.R)(),...e.components};return t?(0,n.jsx)(t,{...e,children:(0,n.jsx)(l,{...e})}):l(e)}},8453:(e,t,r)=>{r.d(t,{R:()=>o,x:()=>i});var n=r(6540);const a={},s=n.createContext(a);function o(e){const t=n.useContext(s);return n.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function i(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(a):e.components||a:o(e.components),n.createElement(s.Provider,{value:t},e.children)}}}]);