using NUnit.Framework;
using Cluno.Api;
using Cluno.Api.Models;
using Cluno.Api.CustomExceptions;
using FluentAssertions;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Net.Http;

namespace Tests
{
    public class Tests
    {
        private Offers _offers = null;
        private List<DetailedOffer> _allDetailedOffers = null;

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            try
            {
                _offers = await Calls.Instance.GetAllOffersAsync();
            }
            catch(HttpRequestException)
            {
                Assert.Fail($"{nameof(Calls.Instance.GetAllOffersAsync)} call failed, statuscode was not 200");
            }
            catch(NullReferenceException)
            {
                Assert.Fail($"{nameof(Calls.Instance.GetAllOffersAsync)} was going to return null");
            }
            catch(SchemaException)
            {
                Assert.Fail($"{nameof(Calls.Instance.GetAllOffersAsync)} json response did not match schema");
            }

            _allDetailedOffers = new List<DetailedOffer>();

            foreach (Offer offer in _offers.Items)
            {
                DetailedOffer detailedOffer = null;
                try
                {
                    detailedOffer = await Calls.Instance.GetDetailedOfferAsync(offer.Id);
                }
                catch (HttpRequestException)
                {
                    Assert.Fail($"{nameof(Calls.Instance.GetDetailedOfferAsync)} call failed, statuscode was not 200");
                }
                catch (NullReferenceException)
                {
                    Assert.Fail($"{nameof(Calls.Instance.GetDetailedOfferAsync)} was going to return null");
                }
                catch (SchemaException)
                {
                    Assert.Fail($"{nameof(Calls.Instance.GetDetailedOfferAsync)} json response did not match schema");
                }

                _allDetailedOffers.Add(detailedOffer);
            }

        }

        [Test]
        public void CountAttributeValue_ShouldBeSameAs_TotalAmountOfOffers()
        {
            _offers.Count.Should().Be(_offers.Items.Length);      
            
        }

        [Test]
        public void AvailableAttributeValue_ShouldBeTrueFor_AllOffers()
        {
            _offers.Items.Any(x => x.Available == false).Should().Be(false);

        }

        [Test]
        public void IsEnvironmentalyFriendlyAttributeValue_ShouldBeTrueFor_OnlyForCarsWithFuelType_ElectricAndHybrid_And_EmissionLabelWith_AandAplus()
        {
            List<string> expectedFuelTypes = new List<string>() { "Electric", "Hybrid" };
            List<string> expectedEmissionLabels = new List<string>() { "A", "A+" };

            _allDetailedOffers.Where(x => x.IsEnvironmentallyFriendly == true).Should()
                .OnlyContain(x => expectedEmissionLabels.Contains(x.Car.FuelType) || expectedEmissionLabels.Contains(x.Car.Environment.EmissionLabel));

        }

        [Test]
        public void IsAvailableAtShortNoticeAttributeValue_ShouldBeTrueFor_OnlyOffers_WhereEstimatedDeliveryTimeIs_WithinNextTwoWeeks()
        {
            _allDetailedOffers.Where(x => x.IsAvailableAtShortNotice == true).Should().OnlyContain(x => x.EstimatedDeliveryTime == "innerhalb von 2 Wochen");
            
        }

        [Test]
        public void AllFamilyVans_ShouldHave_MoreOrEqualThanFiveDoors()
        {
            _allDetailedOffers.Where(x => x.Labels.Contains("Familienvan")).Should().OnlyContain(x => Convert.ToInt32(x.Car.Doors) >= 5);

        }
    }
}