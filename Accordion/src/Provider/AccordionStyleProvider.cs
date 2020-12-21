using Skclusive.Core.Component;

namespace Skclusive.Material.Accordion
{
    public class AccordionStyleProvider : StyleTypeProvider
    {
        public AccordionStyleProvider() : base
        (
            priority: 240,
            typeof(AccordionStyle),
            typeof(AccordionActionsStyle),
            typeof(AccordionDetailsStyle),
            typeof(AccordionSummaryStyle)
        )
        {
        }
    }
}