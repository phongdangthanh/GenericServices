﻿#region licence
// The MIT License (MIT)
// 
// Filename: Perf04EfPostAsync.cs
// Date Created: 2014/06/17
// 
// Copyright (c) 2014 Jon Smith (www.selectiveanalytics.com & www.thereformedprogrammer.net)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using Tests.DataClasses;
using Tests.DataClasses.Concrete;
using Tests.Helpers;

namespace Tests.UnitTests.Group80Performance
{
    class Perf04EfPostAsync
    {

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            using (var db = new SampleWebAppDb())
            {
                DataLayerInitialise.InitialiseThis();
                var filepath = TestFileHelpers.GetTestFileFilePath("DbContentSimple.xml");
                DataLayerInitialise.ResetDatabaseToTestData(db, filepath);
            }
        }


        [Test]
        public async void Check05ListEfDirectOk()
        {
            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                timer.Start();

                //ATTEMPT
                await db.ListEfDirectAsync<Post>(0);
                timer.Stop();

                //VERIFY
                Console.WriteLine("Ef operation took {0} ms",timer.ElapsedMilliseconds);
            }
        }

        [Test]
        public async void Check06ListEfViaDtoOk()
        {
            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                timer.Start();

                //ATTEMPT
                await db.ListPostEfViaDtoAsync(0);
                timer.Stop();

                //VERIFY
                Console.WriteLine("Ef operation took {0} ms", timer.ElapsedMilliseconds);
            }
        }

        [Test]
        public async void Check10CreateEfDirectOk()
        {
            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                timer.Start();

                //ATTEMPT
                await db.CreatePostEfDirectAsync(0);
                timer.Stop();

                //VERIFY
                Console.WriteLine("Ef operation took {0} ms", timer.ElapsedMilliseconds);
            }
        }


        [Test]
        public async void Check11UpdateEfDirectOk()
        {
            int postId;
            using (var db = new SampleWebAppDb())
                postId = db.Posts.AsNoTracking().First().PostId;

            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                timer.Start();

                //ATTEMPT
                await db.UpdatePostEfDirectAsync(postId);
                timer.Stop();

                //VERIFY
                Console.WriteLine("Ef operation took {0} ms", timer.ElapsedMilliseconds);
            }
        }

        [Test]
        public async void Check12DeleteEfDirectOk()
        {
            int postId;
            using (var db = new SampleWebAppDb())
                postId = db.Posts.AsNoTracking().First().PostId;

            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                timer.Start();

                //ATTEMPT
                await db.DeletePostEfDirectAsync(postId);
                timer.Stop();

                //VERIFY
                Console.WriteLine("Ef operation took {0} ms", timer.ElapsedMilliseconds);
            }
        }

    }
}
