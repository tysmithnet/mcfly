// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 02-28-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="RegisterSet.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace McFly.Core
{
    /// <summary>
    ///     Class RegisterSet.
    /// </summary>
    public class RegisterSet
    {
        private ulong _rax;
        private ulong _rbx;
        private ulong _rcx;
        private ulong _rdx;

        /// <summary>
        ///     Gets or sets the rax register
        /// </summary>
        /// <value>The rax register</value>
        public ulong Rax
        {
            get => _rax;
            set => _rax = value;
        }

        /// <summary>
        ///     Gets or sets the rbx register
        /// </summary>
        /// <value>The rbx register</value>
        public ulong Rbx
        {
            get => _rbx;
            set => _rbx = value;
        }

        /// <summary>
        ///     Gets or sets the rcx register
        /// </summary>
        /// <value>The rcx register</value>
        public ulong Rcx
        {
            get => _rcx;
            set => _rcx = value;
        }

        /// <summary>
        ///     Gets or sets the rdx register
        /// </summary>
        /// <value>the rdx register</value>
        public ulong Rdx
        {
            get => _rdx;
            set => _rdx = value;
        }

        public uint Eax
        {
            get => _rax.Lo32();
            set => _rax.Lo32(value);
        }

        public uint Ebx
        {
            get => _rbx.Lo32();
            set => _rbx.Lo32(value);
        }

        public uint Ecx
        {
            get => _rcx.Lo32();
            set => _rcx.Lo32(value);
        }

        public uint Edx
        {
            get => _rdx.Lo32();
            set => _rdx.Lo32(value);
        }
    }
}


/*
64 bit
0:rax
1:rcx
2:rdx
3:rbx
4:rsp
5:rbp
6:rsi
7:rdi
8:r8
9:r9
10:r10
11:r11
12:r12
13:r13
14:r14
15:r15
16:rip
17:efl
18:cs
19:ds
20:es
21:fs
22:gs
23:ss
24:dr0
25:dr1
26:dr2
27:dr3
28:dr6
29:dr7
30:fpcw
31:fpsw
32:fptw
33:st0
34:st1
35:st2
36:st3
37:st4
38:st5
39:st6
40:st7
41:mm0
42:mm1
43:mm2
44:mm3
45:mm4
46:mm5
47:mm6
48:mm7
49:mxcsr
50:xmm0
51:xmm1
52:xmm2
53:xmm3
54:xmm4
55:xmm5
56:xmm6
57:xmm7
58:xmm8
59:xmm9
60:xmm10
61:xmm11
62:xmm12
63:xmm13
64:xmm14
65:xmm15
66:xmm0/0
67:xmm0/1
68:xmm0/2
69:xmm0/3
70:xmm1/0
71:xmm1/1
72:xmm1/2
73:xmm1/3
74:xmm2/0
75:xmm2/1
76:xmm2/2
77:xmm2/3
78:xmm3/0
79:xmm3/1
80:xmm3/2
81:xmm3/3
82:xmm4/0
83:xmm4/1
84:xmm4/2
85:xmm4/3
86:xmm5/0
87:xmm5/1
88:xmm5/2
89:xmm5/3
90:xmm6/0
91:xmm6/1
92:xmm6/2
93:xmm6/3
94:xmm7/0
95:xmm7/1
96:xmm7/2
97:xmm7/3
98:xmm8/0
99:xmm8/1
100:xmm8/2
101:xmm8/3
102:xmm9/0
103:xmm9/1
104:xmm9/2
105:xmm9/3
106:xmm10/0
107:xmm10/1
108:xmm10/2
109:xmm10/3
110:xmm11/0
111:xmm11/1
112:xmm11/2
113:xmm11/3
114:xmm12/0
115:xmm12/1
116:xmm12/2
117:xmm12/3
118:xmm13/0
119:xmm13/1
120:xmm13/2
121:xmm13/3
122:xmm14/0
123:xmm14/1
124:xmm14/2
125:xmm14/3
126:xmm15/0
127:xmm15/1
128:xmm15/2
129:xmm15/3
130:xmm0l
131:xmm1l
132:xmm2l
133:xmm3l
134:xmm4l
135:xmm5l
136:xmm6l
137:xmm7l
138:xmm8l
139:xmm9l
140:xmm10l
141:xmm11l
142:xmm12l
143:xmm13l
144:xmm14l
145:xmm15l
146:xmm0h
147:xmm1h
148:xmm2h
149:xmm3h
150:xmm4h
151:xmm5h
152:xmm6h
153:xmm7h
154:xmm8h
155:xmm9h
156:xmm10h
157:xmm11h
158:xmm12h
159:xmm13h
160:xmm14h
161:xmm15h
162:ymm0
163:ymm1
164:ymm2
165:ymm3
166:ymm4
167:ymm5
168:ymm6
169:ymm7
170:ymm8
171:ymm9
172:ymm10
173:ymm11
174:ymm12
175:ymm13
176:ymm14
177:ymm15
178:ymm0/0
179:ymm0/1
180:ymm0/2
181:ymm0/3
182:ymm1/0
183:ymm1/1
184:ymm1/2
185:ymm1/3
186:ymm2/0
187:ymm2/1
188:ymm2/2
189:ymm2/3
190:ymm3/0
191:ymm3/1
192:ymm3/2
193:ymm3/3
194:ymm4/0
195:ymm4/1
196:ymm4/2
197:ymm4/3
198:ymm5/0
199:ymm5/1
200:ymm5/2
201:ymm5/3
202:ymm6/0
203:ymm6/1
204:ymm6/2
205:ymm6/3
206:ymm7/0
207:ymm7/1
208:ymm7/2
209:ymm7/3
210:ymm8/0
211:ymm8/1
212:ymm8/2
213:ymm8/3
214:ymm9/0
215:ymm9/1
216:ymm9/2
217:ymm9/3
218:ymm10/0
219:ymm10/1
220:ymm10/2
221:ymm10/3
222:ymm11/0
223:ymm11/1
224:ymm11/2
225:ymm11/3
226:ymm12/0
227:ymm12/1
228:ymm12/2
229:ymm12/3
230:ymm13/0
231:ymm13/1
232:ymm13/2
233:ymm13/3
234:ymm14/0
235:ymm14/1
236:ymm14/2
237:ymm14/3
238:ymm15/0
239:ymm15/1
240:ymm15/2
241:ymm15/3
242:ymm0l
243:ymm1l
244:ymm2l
245:ymm3l
246:ymm4l
247:ymm5l
248:ymm6l
249:ymm7l
250:ymm8l
251:ymm9l
252:ymm10l
253:ymm11l
254:ymm12l
255:ymm13l
256:ymm14l
257:ymm15l
258:ymm0h
259:ymm1h
260:ymm2h
261:ymm3h
262:ymm4h
263:ymm5h
264:ymm6h
265:ymm7h
266:ymm8h
267:ymm9h
268:ymm10h
269:ymm11h
270:ymm12h
271:ymm13h
272:ymm14h
273:ymm15h
274:exfrom
275:exto
276:brfrom
277:brto
278:eax
279:ecx
280:edx
281:ebx
282:esp
283:ebp
284:esi
285:edi
286:r8d
287:r9d
288:r10d
289:r11d
290:r12d
291:r13d
292:r14d
293:r15d
294:eip
295:ax
296:cx
297:dx
298:bx
299:sp
300:bp
301:si
302:di
303:r8w
304:r9w
305:r10w
306:r11w
307:r12w
308:r13w
309:r14w
310:r15w
311:ip
312:fl
313:al
314:cl
315:dl
316:bl
317:spl
318:bpl
319:sil
320:dil
321:r8b
322:r9b
323:r10b
324:r11b
325:r12b
326:r13b
327:r14b
328:r15b
329:ah
330:ch
331:dh
332:bh
333:iopl
334:of
335:df
336:if
337:tf
338:sf
339:zf
340:af
341:pf
342:cf
343:vip
344:vif

x86
0:gs
1:fs
2:es
3:ds
4:edi
5:esi
6:ebx
7:edx
8:ecx
9:eax
10:ebp
11:eip
12:cs
13:efl
14:esp
15:ss
16:dr0
17:dr1
18:dr2
19:dr3
20:dr6
21:dr7
22:di
23:si
24:bx
25:dx
26:cx
27:ax
28:bp
29:ip
30:fl
31:sp
32:bl
33:dl
34:cl
35:al
36:bh
37:dh
38:ch
39:ah
40:fpcw
41:fpsw
42:fptw
43:fopcode
44:fpip
45:fpipsel
46:fpdp
47:fpdpsel
48:st0
49:st1
50:st2
51:st3
52:st4
53:st5
54:st6
55:st7
56:mm0
57:mm1
58:mm2
59:mm3
60:mm4
61:mm5
62:mm6
63:mm7
64:mxcsr
65:xmm0
66:xmm1
67:xmm2
68:xmm3
69:xmm4
70:xmm5
71:xmm6
72:xmm7
73:iopl
74:of
75:df
76:if
77:tf
78:sf
79:zf
80:af
81:pf
82:cf
83:vip
84:vif
85:xmm0l
86:xmm1l
87:xmm2l
88:xmm3l
89:xmm4l
90:xmm5l
91:xmm6l
92:xmm7l
93:xmm0h
94:xmm1h
95:xmm2h
96:xmm3h
97:xmm4h
98:xmm5h
99:xmm6h
100:xmm7h
101:xmm0/0
102:xmm0/1
103:xmm0/2
104:xmm0/3
105:xmm1/0
106:xmm1/1
107:xmm1/2
108:xmm1/3
109:xmm2/0
110:xmm2/1
111:xmm2/2
112:xmm2/3
113:xmm3/0
114:xmm3/1
115:xmm3/2
116:xmm3/3
117:xmm4/0
118:xmm4/1
119:xmm4/2
120:xmm4/3
121:xmm5/0
122:xmm5/1
123:xmm5/2
124:xmm5/3
125:xmm6/0
126:xmm6/1
127:xmm6/2
128:xmm6/3
129:xmm7/0
130:xmm7/1
131:xmm7/2
132:xmm7/3
133:ymm0
134:ymm1
135:ymm2
136:ymm3
137:ymm4
138:ymm5
139:ymm6
140:ymm7
141:ymm0l
142:ymm1l
143:ymm2l
144:ymm3l
145:ymm4l
146:ymm5l
147:ymm6l
148:ymm7l
149:ymm0h
150:ymm1h
151:ymm2h
152:ymm3h
153:ymm4h
154:ymm5h
155:ymm6h
156:ymm7h
157:ymm0/0
158:ymm0/1
159:ymm0/2
160:ymm0/3
161:ymm1/0
162:ymm1/1
163:ymm1/2
164:ymm1/3
165:ymm2/0
166:ymm2/1
167:ymm2/2
168:ymm2/3
169:ymm3/0
170:ymm3/1
171:ymm3/2
172:ymm3/3
173:ymm4/0
174:ymm4/1
175:ymm4/2
176:ymm4/3
177:ymm5/0
178:ymm5/1
179:ymm5/2
180:ymm5/3
181:ymm6/0
182:ymm6/1
183:ymm6/2
184:ymm6/3
185:ymm7/0
186:ymm7/1
187:ymm7/2
188:ymm7/3
*/
